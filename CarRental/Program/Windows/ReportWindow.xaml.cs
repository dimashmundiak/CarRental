﻿using System.Windows;

namespace Program
{
    public partial class ReportWindow : Window
    {
        Session s;
        RentedCar rc;
        RepairCar rpc;
        public ReportWindow(Session s, RentedCar rc)
        {
            InitializeComponent();
            this.s = s;
            this.rc = rc;
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            s.Report(rc, double.Parse(mileageBox.Text));
            s.Delete("rented_car", rc.ID);
            if (needRepairBox.IsChecked == true)
            {
                rpc = new RepairCar();
                rpc.Carid = rc.Car_ID;
                rpc.Reason = reasonBox.Text;
                rpc.Price = double.Parse(priceBox.Text);
                s.Repair(rpc);
            }
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
