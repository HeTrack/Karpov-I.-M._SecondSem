﻿using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace SoftShopView
{
    public partial class FormWarehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IWarehouseLogic logic;
        private int? id;
        public FormWarehouse(IWarehouseLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormWarehouse_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.WarehouseName;
                    }
                    var warehouseList = logic.GetList();
                    var warehouseSofts = warehouseList[0].WarehouseSofts;
                    for (int i = 0; i < warehouseList.Count; ++i)
                    {
                        if (warehouseList[i].Id == id)
                        {
                            warehouseSofts = warehouseList[i].WarehouseSofts;
                        }
                    }
                    if (warehouseSofts != null)
                    {
                        dataGridView.DataSource = warehouseSofts;
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].Visible = false;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    logic.UpdElement(new WarehouseBindingModel
                    {
                        Id = id.Value,
                        WarehouseName = textBoxName.Text
                    });
                }
                else
                {
                    logic.AddElement(new WarehouseBindingModel
                    {
                        WarehouseName = textBoxName.Text
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}