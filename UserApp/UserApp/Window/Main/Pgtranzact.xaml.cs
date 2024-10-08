﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserApp.Libs;
using UserApp.Models;

namespace UserApp.Window.Main
{
    /// <summary>
    /// Логика взаимодействия для Pgtranzact.xaml
    /// </summary>
    public partial class Pgtranzact : Page
    {
        int indexNumBillRecipient;
        int indexNumBillSender;
        byte typeTranz;
        private Bill bill;
        bool amountValid = false;
        bool billRecipientValid = false;
        public Pgtranzact()
        {
            InitializeComponent();
            TypeTranz.Items.Add("  Между своими");
            TypeTranz.Items.Add("   Перевод");
            if (NumberSender.Items.Count != 0 || NumberRecipient.Items.Count != 0)
            {
                NumberSender.Items.Clear();
                NumberRecipient.Items.Clear();
            }
            if (User.CurrentUser.Bills.Count != User.CurrentUser.Count)
                User.CurrentUser.Bills.Clear();
            foreach (Bill bill in User.CurrentUser.Bills)
            {
                NumberSender.Items.Add(bill);
                NumberRecipient.Items.Add(bill);
            }
            if (NumberSender.SelectedIndex != -1)
                indexNumBillSender = NumberSender.SelectedIndex;
            try { NumberSender.SelectedIndex = indexNumBillSender; }
            catch { NumberSender.SelectedIndex = 0; }
            BalanceSenderBill.Text = "Баланс: " + (NumberSender.SelectedItem as Bill).Balance.ToString();
            bill = (Bill)NumberSender.SelectedItem;
            try { NumberRecipient.Items.RemoveAt(0); }
            catch { }
        }
        private void TypeTranz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeTranz.SelectedIndex == 0)
            {
                NmRecipient.Visibility = Visibility.Collapsed;
                NumberRecipient.Visibility = Visibility.Visible;

            }
            if (TypeTranz.SelectedIndex == 1)
            {
                NmRecipient.Visibility = Visibility.Visible;
                NumberRecipient.Visibility = Visibility.Collapsed;
            }
        }

        private void NumberSender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded)
            {
                NumberRecipient.Items.Remove(NumberSender.SelectedItem);
                if (bill != null)
                    NumberRecipient.Items.Add(bill);
                bill = (Bill)NumberSender.SelectedItem;
                BalanceSenderBill.Text = "Баланс: " + (NumberSender.SelectedItem as Bill)?.Balance.ToString();
                if (typeTranz == 2)
                    billRecipientValid = false;
            }
        }
        private void BtnComplete_Click(object sender, RoutedEventArgs e)
        {
            if ((NumberSender.SelectedItem as Bill)?.NumberBill == (NumberRecipient.SelectedItem as Bill)?.NumberBill || NmRecipient.Text == (NumberSender.SelectedItem as Bill)?.NumberBill)
            { MessageBox.Show("Указаны одиннаковые счета"); return; }
            if (!(amountValid && billRecipientValid))
            { MessageBox.Show("Введите данные"); return; }
            if ((NumberSender.SelectedItem as Bill).Balance > float.Parse(amount.Text))
            {
                if (TypeTranz.SelectedIndex == 0)
                    typeTranz = 2;
                else
                    typeTranz = 1;
                if (typeTranz == 2)
                    LibBill.BillTransaction(typeTranz, (NumberSender.SelectedItem as Bill)?.NumberBill, (NumberRecipient.SelectedItem as Bill).NumberBill, amount.Text);
                else
                    LibBill.BillTransaction(typeTranz, (NumberSender.SelectedItem as Bill).NumberBill, NmRecipient.Text, amount.Text);
            }
            else
                MessageBox.Show("Недостаточно средств");
            indexNumBillSender = NumberSender.SelectedIndex;
            indexNumBillRecipient = NumberRecipient.SelectedIndex;
            User.CurrentUser.Bills.Clear();
            NumberSender.Items.Clear();
            NumberRecipient.Items.Clear();
            foreach (Bill bill in LibUser.GetBillsByUser(User.CurrentUser))
            {
                NumberSender.Items.Add(bill);
                NumberRecipient.Items.Add(bill);
                User.CurrentUser.Bills.Add(bill);
            }
            NumberSender.SelectedIndex = indexNumBillSender;
            NumberRecipient.SelectedIndex = indexNumBillRecipient;
            BalanceSenderBill.Text = "Баланс: " + (NumberSender.SelectedItem as Bill).Balance.ToString();
            User.CurrentUser.Count = User.CurrentUser.Bills.Count;
        }

        private void Amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (amount.Text == string.Empty)
            { TipReqAmount.Visibility = Visibility.Visible; TipAmount.Visibility = Visibility.Collapsed; amountValid = false; }
            else
            {
                TipReqAmount.Visibility = Visibility.Collapsed;
                if (LibUser.PatternNumber(amount.Text))
                { TipAmount.Visibility = Visibility.Visible; amountValid = false; }
                else
                { TipAmount.Visibility = Visibility.Collapsed; amountValid = true; }
            }
        }
        private void NumberRecipient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NumberRecipient.SelectedIndex == -1)
            { TipReqNmRecipient.Visibility = Visibility.Visible; TipBill.Visibility = Visibility.Collapsed; billRecipientValid = false; }
            else
            { TipReqNmRecipient.Visibility = Visibility.Collapsed; billRecipientValid = true; }
        }
        private void NmRecipient_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (NmRecipient.Text == string.Empty)
            { TipReqNmRecipient.Visibility = Visibility.Visible; TipBill.Visibility = Visibility.Collapsed; billRecipientValid = false; }
            else
            {
                TipReqNmRecipient.Visibility = Visibility.Collapsed;
                if (LibUser.PatternNumber(NmRecipient.Text))
                { TipBill.Visibility = Visibility.Visible; billRecipientValid = false; }
                else
                { TipBill.Visibility = Visibility.Collapsed; billRecipientValid = true; }
            }
        }
    }
}
