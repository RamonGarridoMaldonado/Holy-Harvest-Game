using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto
{
    public string nombreObjeto;
    public int cantidad;

    public Objeto(string objecto, int cant)
    {
        this.nombreObjeto = objecto;
        this.cantidad = cant;
    }

    public void sumarCantidad(int cantidadSumada)
    {
        this.cantidad += cantidadSumada;
    }

    public void restarCantidad(int cantidadRestar)
    {
        this.cantidad -= cantidadRestar;
    }

    public int getCantidad()
    {
        return this.cantidad;
    }

    public Objeto obtenerClaseObjeto ()
    {
        return this;
    }

    public void establecerNuevaCantidad(int nuevaCantidad)
    {
        this.cantidad = nuevaCantidad;
    }
}
