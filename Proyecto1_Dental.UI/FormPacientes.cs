using Proyecto1_Dental.Business.Services;
using Proyecto1_Dental.Models.Entities;
using System;
using System.Windows.Forms;

namespace Proyecto1_Dental.UI
{
    public partial class FormPacientes : Form
    {
        private PacienteService _service = new PacienteService();

        public FormPacientes()
        {
            InitializeComponent();
            this.Load += FormPacientes_Load; // asegura que el evento esté suscrito una sola vez
        }

        private void FormPacientes_Load(object sender, EventArgs e)
        {
            CargarPacientes();
        }

        private void CargarPacientes()
        {
            dgvPacientes.DataSource = null;
            dgvPacientes.DataSource = _service.ObtenerTodos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var nuevo = new Paciente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                FechaRegistro = DateTime.Now
            };

            _service.Crear(nuevo);
            CargarPacientes();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un paciente para actualizar.");
                return;
            }

            var actualizado = new Paciente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text
            };

            _service.Actualizar(actualizado);

            CargarPacientes();
            LimpiarCampos();


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un paciente para eliminar.");
                return;
            }

            int index = dgvPacientes.SelectedRows[0].Index;

            var ok = _service.Eliminar(index);

            if (ok)
            {
                CargarPacientes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el paciente (no encontrado).");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvPacientes.DataSource = null;
            dgvPacientes.DataSource = _service.Buscar(txtNombre.Text);
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPacientes.Rows[e.RowIndex];

            txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
            txtApellido.Text = row.Cells["Apellido"].Value?.ToString();
            txtTelefono.Text = row.Cells["Telefono"].Value?.ToString();
            txtCorreo.Text = row.Cells["Correo"].Value?.ToString();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }
    }
}
