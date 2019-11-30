﻿using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Domain_Servives
{
    public interface IShipmentRepository
    {
        IEnumerable<Shipment> ReadShipments();
        Shipment Create(Shipment Shipment);
        Shipment Delete(int Id);
        Shipment Update(Shipment ShipmentUpdate);
        Shipment FindShipmentWithID(int Id);
    }
}
