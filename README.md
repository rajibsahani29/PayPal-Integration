# PayPal-Integration

PayPal Payment gateway is a Third-party Tool. For using this tool in our application we need to integrate the PayPal API in our Application. First of all for this we have to create an account on PayPal. So that we will get 2 accounts i.e., one for Buyer and another one for Seller.

By logging the details, we can get API Details.so that we can use this API information in our application.

![Banner](https://github.com/rajibsahani29/PayPal-Integration/blob/master/Paypal1.png?raw=true "Banner")


![Banner](https://github.com/rajibsahani29/PayPal-Integration/blob/master/paypal2.png?raw=true "Banner")

Otherwise we can see the API Signature details by logging the Business Account. Go to Profile and Setting Link under Profile, its showed an Option on the left of the opened page “My selling tools”. When you clicked on that link it will show an option for API acess.After click on Update link, you will get an option Manage API credentials under PayPal API Tab, it will show a screen like this.

![Paypal screen](https://github.com/rajibsahani29/PayPal-Integration/blob/master/paypal3.png?raw=true "Paypal screen")


We have implemented this Paypal Payment Gateway in our Spot the Ball Project.In this project,you have to do payment before play a game.
After Login a user can see a page like this to purchase the credits to play a game.

![Paypal screen](https://github.com/rajibsahani29/PayPal-Integration/blob/master/1.png?raw=true "Paypal screen")

When we will click on Paypal Button,it will go to next page with amount for confirmation.

![Paypal screen](https://github.com/rajibsahani29/PayPal-Integration/blob/master/5.png?raw=true "Paypal screen")

This amount will go to next page means Paypal Server.When we will click on Pay Now button,it will move to this Paypal Page.As well as in the button click,we will store all information in a temporary  table in database named as credit_history_temp.

![Paypal screen](https://github.com/rajibsahani29/PayPal-Integration/blob/master/6.png?raw=true "Paypal screen")
![Paypal screen](https://github.com/rajibsahani29/PayPal-Integration/blob/master/3.png?raw=true "Paypal screen")

In the buttom of the page,there will be a “Pay Now” Button.When you will press this button after fill all the information,it will be processed for payement.


![Paypal screen](https://github.com/rajibsahani29/PayPal-Integration/blob/master/4.png?raw=true "Paypal screen")

After successful payment, it will redirect to the Success URL with a Token Id send by PayPal and also payment status as completed.
