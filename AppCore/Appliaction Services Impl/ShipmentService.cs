using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Appliaction_Services_Impl
{
    public class ShipmentService : IShipmentService

    {

        private IShipmentRepository ShipmentRepo;
        public ShipmentService(IShipmentRepository ShipmentRepository)
        {
            ShipmentRepo = ShipmentRepository;
        }
        public Shipment Create(Shipment Shipment)
        {
            return ShipmentRepo.Create(Shipment);
        }

        public Shipment Delete(int Id)
        {
            return ShipmentRepo.Delete(Id);
        }

        public Shipment FindShipmentWithID(int Id)
        {
            return ShipmentRepo.FindShipmentWithID(Id);

        }

        public IEnumerable<Shipment> ReadShipments()
        {
            return ShipmentRepo.ReadShipments();
        }

        public Shipment Update(Shipment ShipmentUpdate)
        {
            return ShipmentRepo.Update(ShipmentUpdate);
        }
    }
}
