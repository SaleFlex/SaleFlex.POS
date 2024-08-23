> **Under development. The solution is not working properly yet.**

# SaleFlex.POS
SaleFlex is a flexible and modular retail automation system designed to empower businesses with seamless management and scalability from anywhere.

# Features
- **Elastic and Modular Design:** Fully customizable to meet the specific needs of any retail environment, whether it's a single store or a chain of outlets.
- **Cloud-Based Control:** Allows you to manage and monitor your business from anywhere, at any time, providing flexibility and convenience.
- **Scalability:** Seamlessly scales as your business grows or changes, ensuring the system can adapt to future needs and challenges.
- **User-Friendly Interface:** Designed for intuitive use, requiring minimal training, making it easy for staff to get up to speed quickly.
- **Database-Free Operation:** SaleFlex operates without the need for a traditional database, generating all necessary data files internally, simplifying setup and maintenance.
- **Windows-Only Compatibility:** Optimized for performance on Windows operating systems, ensuring stability and reliability.
- **Built on .NET 4.8:** Utilizes the robust and mature .NET 4.8 framework, offering high performance, security, and long-term support.

### Project Roadmap

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
- [ ] Form Designer App

Here's the English content for the screen types and their functions in your SaleFlex program:

---

### Screen Types

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

### Sample Configuration Design
#### Login Form

Default login criteria
- username: `CASHIER 1` 
- password: `1234`

![Login Form](https://github.com/SaleFlex/.github/blob/main/profile/saleflex.pos.login.form.sample.jpg?raw=true)

## Contributors

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
- SOL: HS9dUvRSqYGxkDiwTpCvKTVBBWqqtVoXdRK2AanLHMZn
- MATIC: 0xa5a87a939bfcd492f056c26e4febe102ea599b5b
- XTZ: tz1RvnJk5xVtDy2g6ijkcyGSzKA4qFg5Nuy3
