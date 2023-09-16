using System;
using Game.Data;
using Game.Data.Scenes;
using Game.Signals;
using UnityEngine;
using Zenject;

namespace Game.Locations
{
    public class LocationController : IInitializable, IDisposable
    {
        private IDataController dataController;
        private LocationsHolder locationsHolder;
        private SignalBus signalBus;
        
        private LocationScenes currentLocation;
        private Bounds currentLocationBounds;
        
        [Inject]
        private void Construct(IDataController dataController, LocationsHolder locationsHolder,
            SignalBus signalBus)
        {
            this.dataController = dataController;
            this.locationsHolder = locationsHolder;
            this.signalBus = signalBus;
            
            signalBus.Subscribe<LocationChanged>(OnLocationChanged);
        }

        public void Initialize()
        {
            //signalBus.Subscribe<LocationChanged>(OnLocationChanged);
        }

        public void Dispose()
        {
            signalBus?.Unsubscribe<LocationChanged>(OnLocationChanged);
        }
        
        private void OnLocationChanged()
        {
            currentLocation = locationsHolder.Values.Find(x => x.Id == dataController.GetCurrentLocation());
            currentLocationBounds = currentLocation.SceneBounds;
        }

        public bool IsPositionAtLocation(Vector3 position)
        {
            return currentLocationBounds.Contains(position);
        }

        public Vector3 GetSpawnPoint()
        {
            return currentLocation.PlayerSpawnPosition;
        }
    }
}