using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobsPizza
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void OnClick_orderButton(object sender, EventArgs e)
        {
            inputValidationLabel.Text = "";            

            if (allInputIsValid())
            {                
                DTO.OrderDTO newOrder = createOrder();                
                Domain.OrderManager.AddOrderToDB(newOrder);
                Server.Transfer("Success.aspx");
            }
            else
                return;                     
        }    
        
        protected void RecalculateTotalCost(object sender, EventArgs e)
        {
            if (pizzaSizeDropDownList.SelectedValue == "") return;
            if (crustTypeDropDownList.SelectedValue == "") return;
            var order = createOrder();
            totalCostLabel.Text = $"{Domain.PriceManager.CalculateTotalCost(order):C}";
        }

        private bool allInputIsValid()
        {
            bool valid = true;

            checkPizzaSize(ref valid);
            checkCrustType(ref valid);
            checkName(ref valid);
            checkAddress(ref valid);
            checkZip(ref valid);
            checkPhone(ref valid);
            checkPayment(ref valid);

            return valid;
        }
        private void checkPizzaSize(ref bool valid)
        {
            if (pizzaSizeDropDownList.SelectedValue == "")
            {
                valid = false;
                inputValidationLabel.Text += "Please select a pizza size.<br/>";
            }
        }
        private void checkCrustType(ref bool valid)
        {
            if (crustTypeDropDownList.SelectedValue == "")
            {
                valid = false;
                inputValidationLabel.Text += "Please select a crust type.<br/>";
            }
        }
        private void checkName(ref bool valid)
        {
            string name = nameTextBox.Text;
            if (name.Trim() == "" || name.All(char.IsDigit))
            {
                inputValidationLabel.Text += "Please enter your name.<br/>";
                valid = false;
            }
        }
        private void checkAddress(ref bool valid)
        {
            string address = addressTextBox.Text;
            if (address.Trim() == "")
            {
                inputValidationLabel.Text += "Please enter a valid address.<br/>";
                valid = false;
            }
        }
        private void checkZip(ref bool valid)
        {
            string zip = zipTextBox.Text;
            if(zip.Trim() == "" || zip.All(char.IsLetter) || zip.Length != 5 )
            {
                inputValidationLabel.Text += "Please enter a valid zip code.<br/>";
                valid = false;
            }            
        }
        private void checkPhone(ref bool valid)
        {
            string phone = phoneTextBox.Text.Replace("-", "");         
            if(phone.Trim() == "" || phone.All(char.IsLetter)|| phone.Length != 10)
            {
                inputValidationLabel.Text += "Please enter a vaild phone number<br/>";
                valid =  false;
            }            
        }
        private void checkPayment(ref bool valid)
        {
            if (!cashRadioButton.Checked && !creditRadioButton.Checked)
            {
                inputValidationLabel.Text += "Please choose a payment type.";
                valid = false;
            }
        }

        private DTO.OrderDTO createOrder()
        {
            string phoneNumber = formatPhoneNumber();

            DTO.OrderDTO order = new DTO.OrderDTO()
            {
                Size = (DTO.Enums.PizzaSize)Enum.Parse(typeof(DTO.Enums.PizzaSize), pizzaSizeDropDownList.SelectedValue),
                Crust = (DTO.Enums.CrustType)Enum.Parse(typeof(DTO.Enums.CrustType), crustTypeDropDownList.SelectedValue),
                Sausage = sausageCheckBox.Checked,
                Pepperoni = pepperoniCheckBox.Checked,
                Onions = onionsCheckBox.Checked,
                GreenPeppers = greenPeppersCheckBox.Checked,
                Name = nameTextBox.Text,
                Address = addressTextBox.Text,
                Zip = zipTextBox.Text,
                Phone = phoneNumber,
                PaymentType = getPaymentType(),
                TotalCost = 0
            };

            return order;
        }
        private string formatPhoneNumber()
        {
            string phoneNumber = phoneTextBox.Text;
            if (phoneNumber.Length == 10)
                return String.Format($"{double.Parse(phoneNumber):###-###-####}");
            else
                return phoneNumber;            
        }
        private DTO.Enums.PaymentType getPaymentType()
        {
            if (cashRadioButton.Checked)
                return DTO.Enums.PaymentType.Cash;
            else
                return DTO.Enums.PaymentType.Credit;            
        }

        
    }
}