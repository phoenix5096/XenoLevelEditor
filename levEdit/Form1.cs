using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace levEdit
{
    public partial class Form1 : Form
    {
        private List<List<Entity>> level;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitData();
            InitGrid();
            RefreshGrid();
        }

        private void levelGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (levelGrid.SelectedCells.Count == 1)
            {
                propertyGrid.SelectedObject = level[levelGrid.SelectedCells[0].RowIndex][levelGrid.SelectedCells[0].ColumnIndex];
            }
        }

        private void InitData()
        {
            level = new List<List<Entity>>();
            for (int i = 0; i < 100; i++)
            {
                level.Add(new List<Entity>());
                for (int j = 0; j < 100; j++)
                {
                    level[i].Add(new Entity());
                }
            }
        }
        private void InitGrid()
        {
            for (int i = 0; i < 100; i++)
            {
                levelGrid.Columns.Add(i.ToString(), i.ToString());
                levelGrid.Columns[i].Width = levelGrid.RowTemplate.Height;
            }
            levelGrid.Rows.Add(100);
        }
        private void RefreshGrid()
        {
            var e = level.GetEnumerator();
            for (int i = 0; i < level.Count(); i++)
            {
                for (int j = 0; j < level[i].Count(); j++)
                {
                    if (level[i][j] != null)
                    {
                        levelGrid[j,i].Value = level[i][j].ToString();
                    }
                }
            }
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //TODO: only refresh selected item
            RefreshGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(txtFileName.Text, false))
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(level.GetType());
                x.Serialize(file, level);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(txtFileName.Text))
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(level.GetType());
                level = (List<List<Entity>>) x.Deserialize(file);
            }

            RefreshGrid();
        }
    }
}
