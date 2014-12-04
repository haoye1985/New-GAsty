using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GAsty.Hazard.Core;
using GAsty.Network.Core;

namespace GAsty
{
    public static class SerialisationHelper
    {
        public static void SerialiseNetwork(this GeoNetwork infraNetworks)
        {
            var bformatter = new BinaryFormatter();
            using (var file = File.Open(@"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork\LondonUnderground.bin", FileMode.Create))
            {
                try{bformatter.Serialize(file, infraNetworks);}
                catch (Exception)
                { throw;}
            }
        }

        public static void SerialiseHazard(this List<GeoHazardCell> pHazardCellCollection)
        {
            var bformatter = new BinaryFormatter();
            using (var file = File.Open(@"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork\LondonHazard.bin", FileMode.Create))
            {
                try { bformatter.Serialize(file, pHazardCellCollection); }
                catch (Exception)
                { throw; }
            }
        }

        public static void SerialiseNetworkService(this List<GeoNetwork> serviceNetworkCollection)
        {
            var bformatter = new BinaryFormatter();
            using (var file = File.Open(@"C:\Users\hye\Desktop\GAsty\GAsty-master\SampleNetwork\LondonServices.bin", FileMode.Create))
            {
                try { bformatter.Serialize(file, serviceNetworkCollection); }
                catch (Exception)
                { throw; }
            }
        }

        public static GeoNetwork DeserialiseNetwork(string path)
        {
            var network = new GeoNetwork();
            Stream stream = File.Open(path, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            network = (GeoNetwork)bformatter.Deserialize(stream);
            return network;
        }

        public static List<GeoHazardCell> DeserialiseHazard(string path)
        {
            var hazardCellCollection = new List<GeoHazardCell>();
            Stream stream = File.Open(path, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            hazardCellCollection = (List<GeoHazardCell>)bformatter.Deserialize(stream);
            return hazardCellCollection;
        }

        public static List<GeoNetwork> DeserialiseServiceNetworks(string path)
        {
            List<GeoNetwork> networkCollections = new List<GeoNetwork>();
            Stream stream = File.Open(path, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            networkCollections = (List<GeoNetwork>)bformatter.Deserialize(stream);
            return networkCollections;
        }






    }
}
