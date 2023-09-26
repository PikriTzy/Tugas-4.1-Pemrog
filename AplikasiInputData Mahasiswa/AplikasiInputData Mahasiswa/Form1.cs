using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiInputData_Mahasiswa
{
    public partial class Form1 : Form
    {
        private List<Mahasiswa> list = new List<Mahasiswa>();

        public Form1()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                // tampilkan konfirmasi
                var konfirmasi = MessageBox.Show("Apakah data mahasiswa ingin dihapus ? ", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil index list yang di pilih
                    var index = lvwMahasiswa.SelectedIndices[0];
                    // hapus objek mahasiswa dari list
                    list.RemoveAt(index);
                    // refresh tampilan listivew
                    TampilkanData();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void lvwMahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void InisialisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nim", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 200, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Kelas", 70, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai", 50, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai Huruf", 80, HorizontalAlignment.Center);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtNim.Clear();
            txtNama.Clear();
            txtKelas.Clear();
            txtNilai.Text = "0";
            txtNim.Focus();
        }

        private bool NumericOnly(KeyPressEventArgs e)
        {
            var strValid = "0123456789";

            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                if (strValid.IndexOf(e.KeyChar) < 0)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        private void txtNilai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Mahasiswa mhs = new Mahasiswa();

            mhs.Nim = txtNim.Text;
            mhs.Nama = txtNama.Text;
            mhs.Kelas = txtKelas.Text;
            mhs.Nilai = int.Parse(txtNilai.Text);

            if (int.Parse(txtNilai.Text) > 100)
            {
                mhs.Nilaih = "Error";
            }
            else if (int.Parse(txtNilai.Text) > 80)
            {
                mhs.Nilaih = "A";
            }
            else if (int.Parse(txtNilai.Text) > 60)
            {
                mhs.Nilaih = "B";
            }
            else if (int.Parse(txtNilai.Text) > 40)
            {
                mhs.Nilaih = "C";
            }
            else if (int.Parse(txtNilai.Text) > 20)
            {
                mhs.Nilaih = "D";
            }
            else if (int.Parse(txtNilai.Text) < 21)
            {
                mhs.Nilaih = "E";
            }
            else
            {
                mhs.Nilaih = "Error";
            }

            list.Add(mhs);

            var msg = "Data Mahasiswa Berhasil disimpam.";

            MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
        }

        internal class Mahasiswa
        {
            public string Nim { get; internal set; }
            public string Kelas { get; internal set; }
            public string Nama { get; internal set; }
            public int Nilai { get; internal set; }
            public string Nilaih { get; internal set; }

        }

        

        private void TampilkanData()
        {
            // kosongkan data listview
            lvwMahasiswa.Items.Clear();
            // lakukan perulangan untuk menampilkan data mahasiswa ke listview
            foreach (var mhs in list)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Nim);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Kelas);
                item.SubItems.Add(mhs.Nilai.ToString());
                item.SubItems.Add(mhs.Nilaih);
                lvwMahasiswa.Items.Add(item);
            }
        }

        private void btnTampilkanData_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

        
    }
}
