using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Data;
using System.ComponentModel;
using DBConnectionLayer;
using DBConnectionLayerFrontEnd.Commands;
using DBConnectionLayerFrontEnd.Resource;
using DBConnectionLayerFrontEnd.View;
using DBConnectionLayerFrontEnd.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DBConnectionLayerFrontEnd.ViewModel
{
    public class OrderMgtViewModel: WorkSpacesViewModel
    {
        ObservableCollection<InvoiceItemListModel> _invoiceItemList;
        ObservableCollection<WorkSpacesViewModel> _workspaces;
        CommandBase _CreateNewList;
        CommandBase _SaveListToDB;
        InvoiceItemListViewModel _itemListViewModel;
        ConnectToMongoDB _connectedMongo = new ConnectToMongoDB();
        //int generatedInvoiceNumber = 3000;

        public OrderMgtViewModel()
        {

        }

        public void createNewList()
        {
            InvoiceItemListViewModel invoiceItemListViewModel = this.Workspaces.Where(vm => vm.DisplayName == "Invoice List").FirstOrDefault() as InvoiceItemListViewModel;

            if (invoiceItemListViewModel != null)
                this.Workspaces.Remove(invoiceItemListViewModel);
            invoiceItemListViewModel = initiateItemListViewModel(invoiceItemListViewModel);
            this.Workspaces.Add(invoiceItemListViewModel);
            this.SetActiveWorkspace(invoiceItemListViewModel);

        }

        private InvoiceItemListViewModel initiateItemListViewModel(InvoiceItemListViewModel ItemListViewModel)
        {
            _itemListViewModel = new InvoiceItemListViewModel();
            _itemListViewModel.InvoiceList = populateEmptyList();
            return _itemListViewModel;
        }

        ObservableCollection<InvoiceItemListModel> populateEmptyList ()
        {
            ObservableCollection<InvoiceItemListModel> EmptyList = new ObservableCollection<InvoiceItemListModel>();
            try
            {
                EmptyList.Add(new InvoiceItemListModel("", "", "", "", "", ""));
                return EmptyList;
            }
            catch(Exception ex)
            {
                return EmptyList;
            }

        }


        public void saveListToDB()
        {
            int invoiceNumber = 0;

            invoiceNumber = generateInvoiceNumber();

            var invoiceEntity = createInvoiceDBEntity(_itemListViewModel.InvoiceList, invoiceNumber);

            _connectedMongo.insertDocumentToDB(invoiceEntity, "OrderMgtCollection");

            updateInvoiceDBEntity(_itemListViewModel.InvoiceList, invoiceNumber); //in the future replace this with createBsonArray at insert stage to save a step.


        }

        public static BsonArray CreateBsonArray(ObservableCollection<InvoiceItemListModel> invoiceItemList)
        {
            BsonArray createdCollectionBsonArray = new BsonArray();
            BsonArray singleArray = new BsonArray();

            for(int i =0; i<invoiceItemList.Count(); i++)
            {
                singleArray.Add(invoiceItemList[i].itemCatagory);
                singleArray.Add(invoiceItemList[i].invoicedItem);
                singleArray.Add(invoiceItemList[i].unitPrice);
                singleArray.Add(invoiceItemList[i].totalPrice);
                singleArray.Add(invoiceItemList[i].paymentOption);

            }


            createdCollectionBsonArray.Add(singleArray);
            return createdCollectionBsonArray;
        }

        public BsonDocument createInvoiceDBEntity(ObservableCollection<InvoiceItemListModel> invoiceList, int generatedInvoiceNumber)
        {
            var document = new BsonDocument {
                { "Invoice Number" , Convert.ToString(generatedInvoiceNumber)},
                { "Customer Name", customerName},
                { "Invoiced Date", date },
                { "HST", hST},
                { "Discount", discount },

                { "Invoice Detail", new BsonDocument {
                    { "Item Description", invoiceList[0].invoicedItem},
                    { "Item Catagory", invoiceList[0].itemCatagory},
                    { "Item Unit Price", invoiceList[0].unitPrice},
                    { "Item Total Price", invoiceList[0].totalPrice},
                    { "Item Payment", invoiceList[0].paymentOption},
                } }

            };

            return document;
        }
        
        public void updateInvoiceDBEntity(ObservableCollection<InvoiceItemListModel> invoiceList, int generatedInvoiceNumber)
        {
            for(int i = 1; i < invoiceList.Count(); i++)
            {
                var document = new BsonDocument {

                    { "Item Description", invoiceList[i].invoicedItem},
                    { "Item Catagory", invoiceList[i].itemCatagory},
                    { "Item Unit Price", invoiceList[i].unitPrice},
                    { "Item Total Price", invoiceList[i].totalPrice},
                    { "Item Payment", invoiceList[i].paymentOption},
                };



            };

            



        }

        public int generateInvoiceNumber ()
        {
            int generatedInvoiceNumber = 300;
            generatedInvoiceNumber += _connectedMongo.numberOfDocumentsInCollection("OrderMgtCollection");

            return generatedInvoiceNumber;

        }

        public string customerName { get; set; }
        public string date { get; set; }
        public string hST { get; set; }
        public string discount { get; set; }

        #region ICommands
        public ICommand CreateList
        {
            get
            {
                if (_CreateNewList == null)
                {
                    //commandBase(Action<object> executeDelegate, Predicate<object> canExecuteDelegate)
                    //this means commandBase takes 2 object parameters to create constructor
                    //first it will see if this command can be executed by going to CanUpdate
                    //if it cannot execute, it will disable the button
                    //once it gets a true boolean value, it will then proceed to execute
                    //if it can execute: then go to action boject which is updateTextOnCommand()
                    //_updateCommand = new CommandBase(param => this.UpdateTextOnCommand(), Param => this.CanUpdate);
                    _CreateNewList = new CommandBase(param => this.createNewList());
                }
                return _CreateNewList;
            }


        }

        public ICommand SaveListToDB
        {
            get
            {
                if (_SaveListToDB == null)
                {
                    _SaveListToDB = new CommandBase(param => this.saveListToDB());
                }
                return _SaveListToDB;
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
