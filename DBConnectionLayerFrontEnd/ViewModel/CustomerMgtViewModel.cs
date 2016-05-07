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
using System.Windows.Input;
using MongoDB.Bson;
using MongoDB.Driver;
using DBConnectionLayerFrontEnd.Commands;
using DBConnectionLayer;

namespace DBConnectionLayerFrontEnd.ViewModel
{
    public class CustomerMgtViewModel:WorkSpacesViewModel
    {
        ObservableCollection<WorkSpacesViewModel> _workspaces;
        CommandBase _connectToDB;
        CommandBase _insertToDB;
        ConnectToMongoDB _connectedMongo = new ConnectToMongoDB();

        public CustomerMgtViewModel()
        {

        }

        public void insertToDB()
        {
            _connectedMongo.insertTestJson();
        }

        #region Icommands

        public ICommand InsertToDB
        {
            get
            {
                if (_insertToDB == null)
                {
                    //commandBase(Action<object> executeDelegate, Predicate<object> canExecuteDelegate)
                    //this means commandBase takes 2 object parameters to create constructor
                    //first it will see if this command can be executed by going to CanUpdate
                    //if it cannot execute, it will disable the button
                    //once it gets a true boolean value, it will then proceed to execute
                    //if it can execute: then go to action boject which is updateTextOnCommand()
                    //_updateCommand = new CommandBase(param => this.UpdateTextOnCommand(), Param => this.CanUpdate);
                    _insertToDB = new CommandBase(param => this.insertToDB());
                }
                return _insertToDB;
            }


        }

        #endregion  

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
