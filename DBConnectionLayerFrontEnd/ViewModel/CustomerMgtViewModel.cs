using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DBConnectionLayerFrontEnd.View;
using DBConnectionLayerFrontEnd.ViewModel;
using System.Windows.Data;

namespace DBConnectionLayerFrontEnd.ViewModel
{
    public class CustomerMgtViewModel:WorkSpacesViewModel
    {
        ObservableCollection<WorkSpacesViewModel> _workspaces;
        public CustomerMgtViewModel()
        {

        }


        #region mini workspace

        public ObservableCollection<WorkSpacesViewModel> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<WorkSpacesViewModel>();
                    _workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }

                return _workspaces;
            }
        }

        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkSpacesViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkSpacesViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkSpacesViewModel workspace = sender as WorkSpacesViewModel;
            workspace.Dispose();
            this.Workspaces.Remove(workspace);
        }

        void SetActiveWorkspace(WorkSpacesViewModel workspace)
        {
            //Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        #endregion

    }
}
