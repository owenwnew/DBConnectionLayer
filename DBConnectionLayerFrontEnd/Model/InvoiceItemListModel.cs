using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionLayerFrontEnd.Model
{
    public class InvoiceItemListModel
    {
        string _invoicedItem;
        string _quantity;
        string _unitPrice;
        string _totalPrice;
        string _itemCatagory;
        string _paymentOption;

        public InvoiceItemListModel(string InvoicedItem, string Quantity, string UnitPrice, string TotalPrice, string ItemCatagory, string PaymenOption)
        {
            _invoicedItem = InvoicedItem;
            _quantity = Quantity;
            _unitPrice = UnitPrice;
            _totalPrice = TotalPrice;
            _itemCatagory = ItemCatagory;
            _paymentOption = PaymenOption;
        }

        public InvoiceItemListModel()
        {

        }

        public string invoicedItem { get { return _invoicedItem; } set { _invoicedItem = value; } }
        public string quantity { get { return _quantity; } set { _quantity = value; } }
        public string unitPrice { get { return _unitPrice; } set { _unitPrice = value; } }
        public string totalPrice { get { return _totalPrice; } set { _totalPrice = value; } }
        public string itemCatagory { get { return _itemCatagory; } set { _itemCatagory = value; } }
        public string paymentOption { get { return _paymentOption; } set { _paymentOption = value; } }


    }
}
