using System;
using System.Collections.Generic;

namespace ArbolB
{
    public enum ColorNodo
    {
        Default,
        BFS,
        Preorden,
        Inorden,
        Postorden
    }

    public class ArbolBinarioBusqueda
    {
        public class NodoABB
        {
            public int Valor;
            public NodoABB Izquierdo, Derecho;
            public ColorNodo ColorNodo;

            public NodoABB(int valor)
            {
                Valor = valor;
                Izquierdo = Derecho = null;
                ColorNodo = ColorNodo.Default;
            }
        }

        private NodoABB raiz;

        public ArbolBinarioBusqueda()
        {
            raiz = null;
        }

        public NodoABB ObtenerRaiz()
        {
            return raiz;
        }

        public void ReiniciarColores()
        {
            ReiniciarColores(raiz);
        }

        private void ReiniciarColores(NodoABB nodo)
        {
            if (nodo == null)
                return;

            nodo.ColorNodo = ColorNodo.Default;

            ReiniciarColores(nodo.Izquierdo);
            ReiniciarColores(nodo.Derecho);
        }

        public void RecorridoBFS()
        {
            ReiniciarColores();
            RecorridoBFS(raiz);
        }

        private void RecorridoBFS(NodoABB raiz)
        {
            if (raiz == null)
                return;

            Queue<NodoABB> cola = new Queue<NodoABB>();
            cola.Enqueue(raiz);

            RecorridoBFSRecursivo(cola);
        }

        private void RecorridoBFSRecursivo(Queue<NodoABB> cola)
        {
            if (cola.Count == 0)
                return;

            NodoABB nodo = cola.Dequeue();
            nodo.ColorNodo = ColorNodo.BFS;

            if (nodo.Izquierdo != null)
            {
                cola.Enqueue(nodo.Izquierdo);
                nodo.Izquierdo.ColorNodo = ColorNodo.BFS;
            }

            if (nodo.Derecho != null)
            {
                cola.Enqueue(nodo.Derecho);
                nodo.Derecho.ColorNodo = ColorNodo.BFS;
            }

            RecorridoBFSRecursivo(cola);
        }

        public void RecorridoPreorden()
        {
            ReiniciarColores();
            RecorridoPreorden(raiz);
        }

        private void RecorridoPreorden(NodoABB nodo)
        {
            if (nodo == null)
                return;

            nodo.ColorNodo = ColorNodo.Preorden;

            RecorridoPreorden(nodo.Izquierdo);
            RecorridoPreorden(nodo.Derecho);
        }

        public void RecorridoInorden()
        {
            ReiniciarColores();
            RecorridoInorden(raiz);
        }

        private void RecorridoInorden(NodoABB nodo)
        {
            if (nodo == null)
                return;

            RecorridoInorden(nodo.Izquierdo);
            nodo.ColorNodo = ColorNodo.Inorden;
            RecorridoInorden(nodo.Derecho);
        }

        public void RecorridoPostorden()
        {
            ReiniciarColores();
            RecorridoPostorden(raiz);
        }

        private void RecorridoPostorden(NodoABB nodo)
        {
            if (nodo == null)
                return;

            RecorridoPostorden(nodo.Izquierdo);
            RecorridoPostorden(nodo.Derecho);
            nodo.ColorNodo = ColorNodo.Postorden;
        }

        public bool BuscarNodo(int valor)
        {
            return BuscarNodoRecursivo(raiz, valor);
        }

        private bool BuscarNodoRecursivo(NodoABB nodo, int valor)
        {
            if (nodo == null)
                return false;

            if (valor == nodo.Valor)
                return true;

            if (valor < nodo.Valor)
                return BuscarNodoRecursivo(nodo.Izquierdo, valor);
            else
                return BuscarNodoRecursivo(nodo.Derecho, valor);
        }

        public bool BuscarNodoConPadre(int valor, out NodoABB nodo, out NodoABB padre)
        {
            nodo = null;
            padre = null;

            return BuscarNodoRecursivoConPadre(raiz, valor, out padre);
        }

        private bool BuscarNodoRecursivoConPadre(NodoABB nodo, int valor, out NodoABB padre)
        {
            padre = null;

            while (nodo != null)
            {
                if (valor == nodo.Valor)
                    return true;

                padre = nodo;

                if (valor < nodo.Valor)
                    nodo = nodo.Izquierdo;
                else
                    nodo = nodo.Derecho;
            }

            return false;
        }

        public void EliminarNodo(int valor)
        {
            raiz = EliminarNodoRecursivo(raiz, valor);
        }

        private NodoABB EliminarNodoRecursivo(NodoABB nodo, int valor)
        {
            if (nodo == null)
                return nodo;

            if (valor < nodo.Valor)
                nodo.Izquierdo = EliminarNodoRecursivo(nodo.Izquierdo, valor);
            else if (valor > nodo.Valor)
                nodo.Derecho = EliminarNodoRecursivo(nodo.Derecho, valor);
            else
            {
                if (nodo.Izquierdo == null)
                    return nodo.Derecho;
                else if (nodo.Derecho == null)
                    return nodo.Izquierdo;

                nodo.Valor = ValorMaximo(nodo.Izquierdo);

                nodo.Izquierdo = EliminarNodoRecursivo(nodo.Izquierdo, nodo.Valor);
            }

            return nodo;
        }

        private int ValorMaximo(NodoABB nodo)
        {
            int valorMax = nodo.Valor;
            while (nodo.Derecho != null)
            {
                valorMax = nodo.Derecho.Valor;
                nodo = nodo.Derecho;
            }
            return valorMax;
        }


        public void InsertarNodo(int valor)
        {
            raiz = InsertarNodoRecursivo(raiz, valor);
        }

        private NodoABB InsertarNodoRecursivo(NodoABB nodo, int valor)
        {
            if (nodo == null)
                return new NodoABB(valor);

            if (valor < nodo.Valor)
                nodo.Izquierdo = InsertarNodoRecursivo(nodo.Izquierdo, valor);
            else if (valor > nodo.Valor)
                nodo.Derecho = InsertarNodoRecursivo(nodo.Derecho, valor);

            return nodo;
        }
    }
}
