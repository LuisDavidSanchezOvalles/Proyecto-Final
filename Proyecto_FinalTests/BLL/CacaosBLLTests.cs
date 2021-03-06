﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    [TestClass()]
    public class CacaosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Cacaos cacaos = new Cacaos();

            cacaos.CacaoId = 0;
            cacaos.Fecha = DateTime.Now;
            cacaos.Tipo = "Sanchéz";
            cacaos.Cantidad = 0.0m;
            cacaos.Costo = 0.0m;
            cacaos.Precio = 500.0m;
            cacaos.FechaCreacion = DateTime.Now;
            cacaos.FechaModificacion = DateTime.Now;
            cacaos.UsuarioId = 1;

            bool paso = CacaosBLL.Guardar(cacaos);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Cacaos cacaos = new Cacaos();

            cacaos.CacaoId = 1;
            cacaos.Tipo = "Sanchéz";
            cacaos.Cantidad = 0.0m;
            cacaos.Costo = 0.0m;
            cacaos.Precio = 400.0m;
            cacaos.FechaModificacion = DateTime.Now;
            cacaos.UsuarioId = 1;

            bool paso = CacaosBLL.Modificar(cacaos);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Cacaos cacaos = CacaosBLL.Buscar(1);

            Assert.IsTrue(cacaos != null);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = CacaosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Cacaos> listado = CacaosBLL.GetList(c => true);

            Assert.IsTrue(listado != null);
        }

        [TestMethod()]
        public void ExisteCacaoTest()
        {
            bool paso = CacaosBLL.ExisteCacao();

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ActualizarCacaoTest()
        {
            Cacaos cacao = CacaosBLL.Buscar(1);
            decimal cantidad = cacao.Cantidad;

            CacaosBLL.ActualizarCacao(1, 200, 400);

            cacao = CacaosBLL.Buscar(1);

            Assert.IsTrue(cantidad + 200 == cacao.Cantidad && cacao.Costo == 400);
        }

        [TestMethod()]
        public void ContratarCacaoTest()
        {
            Cacaos cacao = CacaosBLL.Buscar(1);

            decimal cantidad = cacao.Cantidad;

            CacaosBLL.ContratarCacao(1, 100);

            cacao = CacaosBLL.Buscar(1);

            Assert.IsTrue(cantidad - 100 == cacao.Cantidad);
        }

        [TestMethod()]
        public void DevolverCacaoTest()
        {
            Cacaos cacao = CacaosBLL.Buscar(1);

            decimal cantidad = cacao.Cantidad;

            CacaosBLL.DevolverCacao(1, 100);

            cacao = CacaosBLL.Buscar(1);

            Assert.IsTrue(cantidad + 100 == cacao.Cantidad);
        }

        [TestMethod()]
        public void cacaoDisponibleTest()
        {
            bool paso = CacaosBLL.cacaoDisponible();

            Assert.IsTrue(paso);
        }
    }
}