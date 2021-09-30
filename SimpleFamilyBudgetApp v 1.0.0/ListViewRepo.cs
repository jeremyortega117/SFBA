using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepo
    {
        internal List<ListViewModel> listViewData;
        internal ListView listViewObject = new ListView();

        public ListViewRepo(ListView lvo)
        {
            listViewObject = lvo;
            listViewData = new List<ListViewModel>();
            FillListViewData(listViewData);
            CreateListViewColumnHeaders(lvo);
        }

        private void FillListViewData(List<ListViewModel> listViewData)
        {
            throw new NotImplementedException();
        }


        private void CreateListViewColumnHeaders(ListView lvo)
        {
            throw new NotImplementedException();
        }
    }
}