﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using DBConnectionLayerFrontEnd.Commands;
using DBConnectionLayer;

namespace DBConnectionLayerFrontEnd.ViewModel
{
    public class FrontEndViewModel : INotifyPropertyChanged
    {
        CommandBase _connectToDB;
        CommandBase _insertToDB;
        ConnectToMongoDB _connectedMongo = new ConnectToMongoDB();

        public FrontEndViewModel()
        {

        }

        

        public void connectToDB()
        {
            _connectedMongo.MongoDBConnection();
        }

        public void insertToDB()
        {
            _connectedMongo.insertTestJson();
        }

        #region Icommands

        public ICommand ConnectToDB
        {
            get
            {
                if (_connectToDB == null)
                {
                    //commandBase(Action<object> executeDelegate, Predicate<object> canExecuteDelegate)
                    //this means commandBase takes 2 object parameters to create constructor
                    //first it will see if this command can be executed by going to CanUpdate
                    //if it cannot execute, it will disable the button
                    //once it gets a true boolean value, it will then proceed to execute
                    //if it can execute: then go to action boject which is updateTextOnCommand()
                    //_updateCommand = new CommandBase(param => this.UpdateTextOnCommand(), Param => this.CanUpdate);
                    _connectToDB = new CommandBase(param => this.connectToDB());
                }
                return _connectToDB;
            }


        }

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

        #region INotification interface
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged; //this is the samething as
            //handler = new event PropertyChangedEventHandler PropertyChanged

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(PropertyName));
            }


        }

        #endregion
    }
}