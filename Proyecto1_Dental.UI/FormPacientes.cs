using Proyecto1_Dental.Business.Services;
using Proyecto1_Dental.Models.Entities;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_Dental.UI
{
    public partial class FormPacientes : Form
    {
        private readonly PacienteService _service = new PacienteService();
        private Paciente _pacienteSeleccionado;

        public FormPacientes()
        {
            InitializeComponent();
            dgvPacientes.CellClick += dgvPacientes_CellClick;
            this.Load += FormPacientes_Load;
        }

        private async void FormPacientes_Load(object sender, EventArgs e)
        {
            await CargarPacientesAsync();
        }

        private async Task CargarPacientesAsync()
        {
            dgvPacientes.DataSource = null;
            dgvPacientes.DataSource = await _service.ObtenerTodosAsync();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var nuevo = new Paciente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                FechaRegistro = DateTime.Now
            };

            await _service.CrearAsync(nuevo);
            await CargarPacientesAsync();
            LimpiarCampos();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_pacienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un paciente para actualizar.");
                return;
            }

            var actualizado = new Paciente
            {
                PacienteID = _pacienteSeleccionado.PacienteID,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                FechaRegistro = _pacienteSeleccionado.FechaRegistro
            };

            await _service.ActualizarAsync(actualizado);
            await CargarPacientesAsync();
            LimpiarCampos();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_pacienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un paciente para eliminar.");
                return;
            }

            var ok = await _service.EliminarAsync(_pacienteSeleccionado.PacienteID);

            if (ok)
            {
                await CargarPacientesAsync();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el paciente (no encontrado).");
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            _pacienteSeleccionado = null;
            dgvPacientes.DataSource = null;
            dgvPacientes.DataSource = await _service.BuscarAsync(txtNombre.Text);
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPacientes.Rows[e.RowIndex];
            _pacienteSeleccionado = row.DataBoundItem as Paciente;

            if (_pacienteSeleccionado == null) return;

            txtNombre.Text = _pacienteSeleccionado.Nombre;
            txtApellido.Text = _pacienteSeleccionado.Apellido;
            txtTelefono.Text = _pacienteSeleccionado.Telefono;
            txtCorreo.Text = _pacienteSeleccionado.Correo;
        }

        private void LimpiarCampos()
        {
            _pacienteSeleccionado = null;
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }
    }
}
