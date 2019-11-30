using AppCore.Domain_Servives;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLData.Repos
{
    public class ShipmentRepository : IShipmentRepository
    {
        

        readonly FitLineContext context;

        public ShipmentRepository(FitLineContext ctx)
        {
            context = ctx;
        }

        public Shipment Create(Shipment Shipment)
        {
            context.Shipments.Add(Shipment);
            context.SaveChanges();
            return context.Shipments.Find(Shipment.ID);
        }

        public Shipment Delete(int Id)
        {
            context.Shipments.Remove(FindShipmentWithID(Id));
            context.SaveChanges();
            return null;
        }

        public Shipment FindShipmentWithID(int Id)
        {
            return context.Shipments.FirstOrDefault(p => p.ID == Id);

        }

        public IEnumerable<Shipment> ReadShipments()
        {
            return context.Shipments;
        }

        public Shipment Update(Shipment ShipmentUpdate)
        {
            context.Attach(ShipmentUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return context.Shipments.Find(FindShipmentWithID(ShipmentUpdate.ID));
        }
    }
    }

