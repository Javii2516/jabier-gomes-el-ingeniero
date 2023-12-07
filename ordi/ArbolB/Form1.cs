using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static ArbolB.ArbolBinarioBusqueda;

namespace ArbolB
{
    public partial class Form1 : Form
    {
        private ArbolBinarioBusqueda arbol;
        private TextBox txtValor;
        private Button btnInsertar;
        private Button btnBuscar;
        private Button btnEliminar;
        private Button btnBFS;
        private Button btnPreorden;
        private Button btnInorden;
        private Button btnPostorden;
        private Panel panelArbol;
        private Label lblRecorrido;

        public Form1()
        {
            InitializeComponent();
            arbol = new ArbolBinarioBusqueda();
        }

        private void DibujarArbol()
        {
            Graphics g = panelArbol.CreateGraphics();
            LimpiarFormulario(g);
            DibujarNodo(arbol.ObtenerRaiz(), panelArbol.Width / 2, 50, g, panelArbol.Width / 4);
        }

        private void DibujarNodo(ArbolBinarioBusqueda.NodoABB nodo, int x, int y, Graphics g, int separacion)
        {
            if (nodo != null)
            {
                Brush brush = ObtenerColorNodo(nodo);

                Pen pen = new Pen(Color.Black);
                g.FillEllipse(brush, x, y, 30, 30);
                g.DrawEllipse(pen, x, y, 30, 30);
                g.DrawString(nodo.Valor.ToString(), Font, Brushes.White, x + 8, y + 8);

                if (nodo.Izquierdo != null)
                    DibujarLinea(x + 15, y + 30, x - separacion, y + 60, g);
                if (nodo.Derecho != null)
                    DibujarLinea(x + 15, y + 30, x + separacion, y + 60, g);

                DibujarNodo(nodo.Izquierdo, x - separacion, y + 60, g, separacion / 2);
                DibujarNodo(nodo.Derecho, x + separacion, y + 60, g, separacion / 2);
            }
        }

        private void DibujarLinea(int x1, int y1, int x2, int y2, Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, x1, y1, x2, y2);
        }

        private void LimpiarFormulario(Graphics g)
        {
            g.Clear(panelArbol.BackColor);
        }

        private Brush ObtenerColorNodo(ArbolBinarioBusqueda.NodoABB nodo)
        {
            if (nodo.ColorNodo == ColorNodo.BFS)
                return Brushes.Orange;
            else if (nodo.ColorNodo == ColorNodo.Preorden)
                return Brushes.Green;
            else if (nodo.ColorNodo == ColorNodo.Inorden)
                return Brushes.Blue;
            else if (nodo.ColorNodo == ColorNodo.Postorden)
                return Brushes.Red;
            else
                return Brushes.Black;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtValor.Text, out int valor))
            {
                arbol.InsertarNodo(valor);
                DibujarArbol();
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico valido.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtValor.Text, out int valor))
            {
                if (arbol.BuscarNodoConPadre(valor, out var nodo, out var padre))
                {
                    MessageBox.Show($"Nodo con valor {valor} encontrado. El padre es {(padre != null ? padre.Valor.ToString() : "N/A")}");
                }
                else
                {
                    MessageBox.Show($"Nodo con valor {valor} no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido.");
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtValor.Text, out int valor))
            {
                arbol.EliminarNodo(valor);
                DibujarArbol();
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido.");
            }
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            arbol.RecorridoBFS();
            DibujarArbol();
            MostrarResultadoRecorrido("Recorrido Anchura: " + ObtenerResultadoRecorrido(arbol.ObtenerRaiz(), ColorNodo.BFS));
        }

        private void btnPreorden_Click(object sender, EventArgs e)
        {
            arbol.ReiniciarColores();
            arbol.RecorridoPreorden();
            DibujarArbol();
            MostrarResultadoRecorrido("Recorrido Preorden: " + ObtenerResultadoRecorrido(arbol.ObtenerRaiz(), ColorNodo.Preorden));
        }

        private void btnInorden_Click(object sender, EventArgs e)
        {
            arbol.ReiniciarColores();
            arbol.RecorridoInorden();
            DibujarArbol();
            MostrarResultadoRecorrido("Recorrido Inorden: " + ObtenerResultadoRecorrido(arbol.ObtenerRaiz(), ColorNodo.Inorden));
        }

        private void btnPostorden_Click(object sender, EventArgs e)
        {
            arbol.ReiniciarColores();
            arbol.RecorridoPostorden();
            DibujarArbol();
            MostrarResultadoRecorrido("Recorrido Postorden: " + ObtenerResultadoRecorrido(arbol.ObtenerRaiz(), ColorNodo.Postorden));
        }

        private void MostrarResultadoRecorrido(string resultado)
        {
            lblRecorrido.Text = resultado;
        }

        private string ObtenerResultadoRecorrido(ArbolBinarioBusqueda.NodoABB nodo, ColorNodo tipoRecorrido)
{
    if (nodo == null)
        return "";

    string resultado = "";

    if (tipoRecorrido == ColorNodo.BFS)
    {
        Queue<NodoABB> cola = new Queue<NodoABB>();
        cola.Enqueue(nodo);

        while (cola.Count > 0)
        {
            NodoABB actual = cola.Dequeue();
            resultado += actual.Valor + " ";

            if (actual.Izquierdo != null)
                cola.Enqueue(actual.Izquierdo);

            if (actual.Derecho != null)
                cola.Enqueue(actual.Derecho);
        }
    }
    else
    {
        if (tipoRecorrido == ColorNodo.Preorden)
            resultado += nodo.Valor + " ";

        resultado += ObtenerResultadoRecorrido(nodo.Izquierdo, tipoRecorrido);

        if (tipoRecorrido == ColorNodo.Inorden)
            resultado += nodo.Valor + " ";

        resultado += ObtenerResultadoRecorrido(nodo.Derecho, tipoRecorrido);

        if (tipoRecorrido == ColorNodo.Postorden)
            resultado += nodo.Valor + " ";
    }

    return resultado;
}
    }
}
