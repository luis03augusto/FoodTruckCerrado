﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.Models
{
    public class FotosEventos :Fotos
    {
        public virtual int EventoId { get; set; }

        public virtual Evento Evento { get; set; }
    }
}