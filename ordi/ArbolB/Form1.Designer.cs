namespace ArbolB
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            arbol.RecorridoBFS();
            DibujarArbol();
            MostrarResultadoRecorrido("Recorrido Anchura: " + ObtenerResultadoRecorrido(arbol.ObtenerRaiz(), ColorNodo.BFS));
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "Árbol Binario";

            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtValor.Location = new System.Drawing.Point(10, 10);
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(this.txtValor);

            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.Location = new System.Drawing.Point(120, 10);
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            this.Controls.Add(this.btnInsertar);

            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location = new System.Drawing.Point(230, 10);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.Controls.Add(this.btnBuscar);

            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(340, 10);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.Controls.Add(this.btnEliminar);

            this.btnBFS = new System.Windows.Forms.Button();
            this.btnBFS.Text = "Anchura";
            this.btnBFS.Location = new System.Drawing.Point(10, 40);
            this.btnBFS.Click += new System.EventHandler(this.btnBFS_Click);
            this.Controls.Add(this.btnBFS);

            this.btnPreorden = new System.Windows.Forms.Button();
            this.btnPreorden.Text = "Preorden";
            this.btnPreorden.Location = new System.Drawing.Point(140, 40);
            this.btnPreorden.Click += new System.EventHandler(this.btnPreorden_Click);
            this.Controls.Add(this.btnPreorden);

            this.btnInorden = new System.Windows.Forms.Button();
            this.btnInorden.Text = "Inorden";
            this.btnInorden.Location = new System.Drawing.Point(290, 40);
            this.btnInorden.Click += new System.EventHandler(this.btnInorden_Click);
            this.Controls.Add(this.btnInorden);

            this.btnPostorden = new System.Windows.Forms.Button();
            this.btnPostorden.Text = "Postorden";
            this.btnPostorden.Location = new System.Drawing.Point(440, 40);
            this.btnPostorden.Click += new System.EventHandler(this.btnPostorden_Click);
            this.Controls.Add(this.btnPostorden);

            this.panelArbol = new System.Windows.Forms.Panel();
            this.panelArbol.Location = new System.Drawing.Point(10, 80);
            this.panelArbol.Size = new System.Drawing.Size(780, 400);
            this.Controls.Add(this.panelArbol);

            this.lblRecorrido = new System.Windows.Forms.Label();
            this.lblRecorrido.Location = new System.Drawing.Point(10, 490);
            this.lblRecorrido.Size = new System.Drawing.Size(780, 20);
            this.Controls.Add(this.lblRecorrido);
        }
    }
}
