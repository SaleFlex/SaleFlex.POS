> **Under development. The solution is not working properly yet.**

# SaleFlex
**SaleFlex** is designed to meet the challenges of modern retail businesses, providing flexibility, scalability, and centralized control in one powerful solution.

# SaleFlex.POS
**SaleFlex.POS** is a sales Point of Sale (POS) application designed to work seamlessly with both touch-screen and keyboard-operated systems. It can be deployed as a standalone solution or integrated with **SaleFlex.GATE**, offering a robust, centralized management system for businesses with multiple POS terminals.

# SaleFlex.GATE
[**SaleFlex.GATE**](https://github.com/SaleFlex/SaleFlex.GATE) enhances the capabilities of SaleFlex.POS by providing a centralized control hub that supports inventory and sales tracking across multiple locations. Additionally, SaleFlex.GATE can exchange data with Enterprise Resource Planning (ERP) systems when required, ensuring smooth integration with broader business operations.

# Project Roadmap

- [X] Database Structure
- [ ] Data Access Layer
- [ ] POS Manager Module
- [X] User Interface Modules:
  - [X] Dynamic Interface Interpreter Module
  - [X] Interface Functions
  - [X] Custom Form Module
- [ ] SPU/PLU Management Module
- [ ] Customer Module
- [ ] Printer Module
- [ ] Payment Module
- [ ] Loyalty Module
- [ ] Backend Integration Module
- [ ] Campaign Module
- [ ] Reports Module
- [ ] Warehouse Module
- [ ] Form Designer App

# Features
- **Elastic and Modular Design:** Fully customizable to meet the specific needs of any retail environment, whether it's a single store or a chain of outlets. SaleFlex is fully customizable, allowing businesses to adapt the system to their unique needs.
- **Cloud-Based Control:** [SaleFlex.GATE](https://github.com/SaleFlex/SaleFlex.GATE), an API-based project, enables remote management and monitoring of your business from anywhere, at any time, offering unparalleled flexibility and convenience. SaleFlex.GATE can also connect with mobile applications, providing on-the-go access and control. Additionally, it supports ERP integrations, allowing for seamless connectivity with enterprise systems as needed.
- **Scalability and Future-Proof:** Seamlessly scales as your business grows or changes, ensuring the system can adapt to future needs and challenges. The system grows with your business, ensuring long-term flexibility and cost efficiency.
- **User-Friendly Interface:** Designed for intuitive use, requiring minimal training, making it easy for staff to get up to speed quickly.
- **Database-Free Operation:** SaleFlex operates without the need for a traditional database, generating all necessary data files internally, simplifying setup and maintenance.
- **Windows-Only Compatibility:** Optimized for performance on Windows operating systems, ensuring stability and reliability.
- **Built on .NET 4.8:** Utilizes the robust and mature .NET 4.8 framework, offering high performance, security, and long-term support.
- **Open-Source Advantage:** SaleFlex is an open-source project, offering full transparency and the ability to adapt the system as needed.

## Screen Types

This list represents the customizable screens available in the SaleFlex program. If a screen type is not defined in the database, it will not be visible to the user when the SaleFlex program runs. Additionally, users can modify the content of these screens according to their needs.

1. **SALE:**  
   - [X] **Function:** Sales screen. Allows real-time product selection and sales, converting an order or check into a sale and closing the account.
2. **LOGIN:**  
   - [X] **Function:** Simple login screen. Contains only the username and password fields for user login.
3. **LOGIN_EXT:**  
   - [ ] **Function:** Extended login screen. May include features for accessing the admin menu. Users can also log out from this screen.
4. **LOGIN_SERVICE:**  
   - [ ] **Function:** Extended login screen with additional service menu access features.
5. **SERVICE:**  
   - [ ] **Function:** Service menu. Typically used by technical support staff for system maintenance and troubleshooting.
6. **SETTING:**  
   - [ ] **Function:** Settings screen. Allows users to modify the program's settings stored in the `settings.json` file and the database.
7. **PARAMETER:**  
   - [ ] **Function:** Parameter screen. Enables manual retrieval of parameters from the server for online applications.
8. **REPORT:**  
   - [ ] **Function:** Reporting screen. Displays various basic reports related to the program’s operation.
9. **FUNCTION:**  
   - [ ] **Function:** Function menu. Shows a menu of different program functions available for selection.
10. **CUSTOMER:**  
    - [ ] **Function:** Customer screen. Used for defining new customers or viewing details of existing customers.
11. **VOID:**  
    - [ ] **Function:** Void screen. Allows the cancellation of transactions.
12. **REFUND:**  
    - [ ] **Function:** Refund screen. Manages the processing of transaction refunds.
13. **STOCK:**  
    - [ ] **Function:** Stock screen. Lists products and allows the definition and management of product details.
14. **END_OF_DAY:**  
    - [ ] **Function:** End-of-day screen. Used to close the business day in the system.
15. **TABLE:**  
    - [ ] **Function:** Table screen. Displays a list of tables and their status in restaurant-enabled programs.
16. **ORDER:**  
    - [ ] **Function:** Order screen. Allows the input and display of orders in the system.
17. **CHECK:**  
    - [ ] **Function:** Check screen. Enables the entry and display of checks (bills) in the system.
18. **EMPLOYEE:**  
    - [ ] **Function:** Employee screen. Displays employee details and information related to their rights and records.
19. **RESERVATION:**  
    - [ ] **Function:** Reservation screen. Manages reservations in restaurant-enabled programs.
20. **WAREHOUSE**: 
    - [ ] **Function**: Allows the definition of warehouse locations and the management of warehouse operations within SaleFlex.POS. If SaleFlex.GATE is used, warehouse operations will be managed centrally. Additionally, it can be integrated with third-party systems if desired.

Let me know if you need further assistance or any other changes!

## Supported Payment Types
The value in parentheses shows the equivalent in the database.

- [ ] **CASH (1)**: Payment made using physical cash.
- [ ] **CREDIT_CARD (2)**: Payment made using a credit card.
- [ ] **CHECK (3)**: Payment made via check.
- [ ] **CREDIT_NOCARD (4)**: Payment made using the customer's internal credit within the institution, or through an integration with a bank where the payment is processed using a credit line.
- [ ] **PREPAID_CARD (5)**: Payment made using a prepaid card.
- [ ] **MOBILE (6)**: Payment made via mobile payment methods, such as mobile wallets or payment apps.
- [ ] **BONUS (7)**: Payment made using points or bonuses earned through loyalty programs or rewards.
- [ ] **EXCHANGE (8)**: Payment made in a foreign currency or through currency exchange.
- [ ] **ON_CREDIT (9)**: Payment made on credit, where the amount is recorded as a debt to be paid later (similar to a store credit or purchase on account).
- [ ] **OTHER (10)**: Any other payment type not covered by the above categories.

## Supported Document Types

- [ ] **FiscalReceipt**: A fiscal receipt, typically used for official sales transactions that are recorded for tax purposes.
- [ ] **NoneFiscalReceipt**: A non-fiscal receipt, which is not used for tax purposes but may be issued for internal records or other non-tax-related transactions.
- [ ] **Invoice**: A printed or standard invoice, used to request payment for goods or services provided.
- [ ] **EInvoice**: An electronic invoice, typically sent and processed digitally as part of e-commerce or digital business transactions.
- [ ] **EArchiveInvoice**: An electronic archive invoice, used to store and manage invoices digitally for compliance and record-keeping.
- [ ] **DiplomaticInvoice**: A diplomatic invoice, used for transactions involving diplomatic entities, often exempt from certain taxes.
- [ ] **Waybill**: A transportation document that details the goods being shipped and the terms of their transport.
- [ ] **DeliveryNote**: A delivery note, used to document the items delivered to a customer or another party, often accompanying the goods.
- [ ] **CashOutflow**: A cash outflow document, used to record cash payments or withdrawals from the cash register or account.
- [ ] **CashInflow**: A cash inflow document, used to record cash receipts or deposits into the cash register or account.
- [ ] **Return**: A return document, used to record the return of goods, typically resulting in a credit or refund.
- [ ] **SelfBillingInvoice**: A self-billing invoice, where the buyer issues an invoice on behalf of the supplier, often used in specific business arrangements.

# Sample Configuration Design
## Login Form

Default login criteria
- username: `CASHIER 1` 
- password: `1234`

![Login Form](https://github.com/SaleFlex/.github/blob/main/profile/saleflex.pos.login.form.sample.jpg?raw=true)

## Sale Form

![Sale Form](https://github.com/SaleFlex/.github/blob/main/profile/saleflex.pos.sale.form.sample.jpg?raw=true)

# Contributors

<table>
<tr>
    <td align="center">
        <a href="https://github.com/ferhat-mousavi">
            <img src="https://avatars.githubusercontent.com/u/5930760?v=4" width="100;" alt="Ferhat Mousavi"/>
            <br />
            <sub><b>Ferhat Mousavi</b></sub>
        </a>
    </td>
</tr>
</table>

# Donation and Support
If you like the project and want to support it or if you want to contribute to the development of new modules, you can donate to the following crypto addresses.

- USDT: 0xa5a87a939bfcd492f056c26e4febe102ea599b5b
- BUSD: 0xa5a87a939bfcd492f056c26e4febe102ea599b5b
- BTC: 184FDZ1qV2KFzEaNqMefw8UssG8Z57FA6F
- ETH: 0xa5a87a939bfcd492f056c26e4febe102ea599b5b
- SOL: Gt3bDczPcJvfBeg9TTBrBJGSHLJVkvnSSTov8W3QMpQf
