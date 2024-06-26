﻿using CorsiFormazione.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Application.Abstractions.Services
{
    public interface IUtenteService
    {
        void AggiungiUtente(Utente utente);
        Utente PrendiUtente(string email, string password);
    }
}
