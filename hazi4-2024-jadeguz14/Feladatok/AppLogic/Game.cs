using System;
using System.Collections.Generic;
using System.Threading;
using Windows.Devices.WiFiDirect;

namespace MultiThreadedApp.AppLogic;


class Game
{
    // Különböző vonalak x pozíciója (start, depo, finish)
    public const int StartLinePosition = 150;
    public const int DepoPosition = 300;
    public const int FinishLinePosition = 450;

    public List<int> log = new List<int>();
    private bool hasWinner = false;
    private object syncObject = new object();

    private ManualResetEvent raceStartEvent = new ManualResetEvent(false);
    private AutoResetEvent raceContinueFromDepo = new AutoResetEvent(false);

    public Action<Bike> uiUpdateDelegate;

    public List<Bike> Bikes { get; } = new List<Bike>();

    /// <summary>
    /// Verseny előkészítése (biciklik létrehozása és felsorakoztatása
    /// a startvonalhoz)
    /// </summary>
    public void PrepareRace(Action<Bike> _uiUpdateDelegate)
    {
        uiUpdateDelegate = _uiUpdateDelegate;
        CreateBike();
        CreateBike();
        CreateBike();
    }

    /// <summary>
    /// Elindítja a bicikliket a startvonalról.
    /// </summary>
    public void StartBikes()
    {
        raceStartEvent.Set();
    }

    /// <summary>
    /// Elindítja a következő biciklit a depóból (mindig csak egyet)
    /// </summary>
    public void StartNextBikeFromDepo()
    {
        raceContinueFromDepo.Set();
    }

    /// <summary>
    /// Létrehoz egy biciklit.
    /// </summary>
    private void CreateBike()
    {
        // Az új bicikli a következő rajtszámot kapja paraméterben (az első bicikli a 0 rajtszámot kapja)
        var bike = new Bike(Bikes.Count);
        Bikes.Add(bike);

        var thread = new Thread(BikeThreadFunction);
        thread.IsBackground = true; // Ne blokkolja a szál a processz megszűnését
        thread.Start(bike); // itt adjuk át paraméterben a szálfüggvénynek a biciklit
    }

    void BikeThreadFunction(object bikeAsObject)
    {
        Bike bike = (Bike)bikeAsObject;
        while (bike.Position <= StartLinePosition)
        {
            lock(syncObject)
            {
                log.Add(bike.Step());
                uiUpdateDelegate?.Invoke(bike);
                //bike.Step();
            }
            Thread.Sleep(100);
        }

        while (bike.Position <= DepoPosition)
        {
            if(raceStartEvent.WaitOne())
            {
                lock (syncObject)
                {
                    log.Add(bike.Step());
                    uiUpdateDelegate?.Invoke(bike);
                    //bike.Step();
                }
                Thread.Sleep(100);
            }
        }

        if(raceContinueFromDepo.WaitOne())
        {
            while (bike.Position <= FinishLinePosition)
            {
                lock (syncObject)
                {
                    log.Add(bike.Step());
                    uiUpdateDelegate?.Invoke(bike);
                    //bike.Step();
                }
                lock (syncObject)
                {
                    if (bike.Position >= FinishLinePosition && !hasWinner)
                    {
                        bike.SetAsWinner();
                        hasWinner = true;
                        uiUpdateDelegate?.Invoke(bike);
                    }
                }
                Thread.Sleep(100);
            }
        }
    }
}
