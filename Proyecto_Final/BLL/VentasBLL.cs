﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Entidades;
using Proyecto_Final.DAL;
using System.Linq.Expressions;
using System.Linq;

namespace Proyecto_Final.BLL
{
    public class VentasBLL
    {
        public static bool Guardar(Ventas venta)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Ventas.Add(venta) != null)
                    paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Ventas venta)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM VentasDetalle Where OrdenId = {venta.VentaId}");

                foreach (var item in venta.VentaDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(venta).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Ventas Buscar(int Id)
        {
            Contexto db = new Contexto();
            Ventas venta = new Ventas();

            try
            {
                venta = db.Ventas.Include(v => v.VentaDetalle).Where(v => v.VentaId == Id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return venta;
        }

        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var Eliminar = VentasBLL.Buscar(id);
                db.Entry(Eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> venta)
        {
            Contexto db = new Contexto();
            List<Ventas> Lista = new List<Ventas>();

            try
            {
                Lista = db.Ventas.Where(venta).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}