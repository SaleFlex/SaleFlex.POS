using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleFlex.CommonLibrary;
using SaleFlex.Windows;

namespace SaleFlex.Data.Initialize
{
    public partial class DbCreate
    {
        public static bool bCreatePosDb()
        {
            bool bReturnValue = true;

            if (!File.Exists(CommonProperty.prop_strDatabasePosFileNameAndPath))
                SQLiteConnection.CreateFile(CommonProperty.prop_strDatabasePosFileNameAndPath);        // Create the file which will be hosting our database

            var DbTableCreateMethods = new List<Func<bool>>
            {
                bCreateTableCashier,
                bCreateTableCountry,
                bCreateTableCity,
                bCreateTableDistrict,
                bCreateTableCurrency,
                bCreateTableForm,
                bCreateTableFormControl,
                bCreateTableLabelValue,
                bCreateTablePaymentType,
                bCreateTablePos
            };

            foreach (var DbTableCreateMethod in DbTableCreateMethods)
            {
                if (!DbTableCreateMethod())
                {
                    bReturnValue = false;
                    break;
                }
            }

            return bReturnValue;
        }

        private static bool bCreateTableCashier()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableCashier (
                        Id                      INTEGER PRIMARY KEY ASC AUTOINCREMENT
                                                        UNIQUE
                                                        NOT NULL,
                        No                      INTEGER NOT NULL,
                        Name                    TEXT    NOT NULL,
                        LastName                TEXT    NOT NULL,
                        Password                TEXT    NOT NULL,
                        IdentityNumber          TEXT,
                        Description             TEXT,
                        IsAdministrator         INTEGER NOT NULL
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                        {
                            bReturnValue = true;
                            if (CommonProperty.prop_bIsOfflinePos)
                            {
                                xSQLiteCommand.CommandText = "INSERT INTO TableCashier (No, Name, LastName, Password, IsAdministrator) " +
                                                            $"VALUES (1, 'CASHIER 1','','1234', 0)";
                                iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
                            }
                        }

                        xSQLiteConnection.Close();        // Close the connection to the database
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }

        private static bool bCreateTableCountry()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableCountry (
                        Id          INTEGER PRIMARY KEY ASC AUTOINCREMENT
                                              UNIQUE
                                            NOT NULL,
                        Name        TEXT    NOT NULL,
                        Code        TEXT,
                        ShortName   TEXT,
                        NumericCode INTEGER
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                        {
                            bReturnValue = true;
                            if (CommonProperty.prop_bIsOfflinePos)
                            {
                                string[] straCountries = new string[]
                                {
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Afghanistan', 'AF', 'AFG', 4);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Albania', 'AL', 'ALB', 8);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Algeria', 'DZ', 'DZA', 12);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Andorra', 'AD', 'AND', 20);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Angola', 'AO', 'AGO', 24);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Argentina', 'AR', 'ARG', 32);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Armenia', 'AM', 'ARM', 51);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Australia', 'AU', 'AUS', 36);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Austria', 'AT', 'AUT', 40);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Azerbaijan', 'AZ', 'AZE', 31);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Bahamas', 'BS', 'BHS', 44);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Bahrain', 'BH', 'BHR', 48);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Bangladesh', 'BD', 'BGD', 50);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Barbados', 'BB', 'BRB', 52);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Belarus', 'BY', 'BLR', 112);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Belgium', 'BE', 'BEL', 56);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Belize', 'BZ', 'BLZ', 84);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Benin', 'BJ', 'BEN', 204);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Bhutan', 'BT', 'BTN', 64);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Bolivia', 'BO', 'BOL', 68);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Bosnia and Herzegovina', 'BA', 'BIH', 70);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Botswana', 'BW', 'BWA', 72);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Brazil', 'BR', 'BRA', 76);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Brunei', 'BN', 'BRN', 96);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Bulgaria', 'BG', 'BGR', 100);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Burkina Faso', 'BF', 'BFA', 854);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Burundi', 'BI', 'BDI', 108);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Cabo Verde', 'CV', 'CPV', 132);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Cambodia', 'KH', 'KHM', 116);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Cameroon', 'CM', 'CMR', 120);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Canada', 'CA', 'CAN', 124);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Central African Republic', 'CF', 'CAF', 140);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Chad', 'TD', 'TCD', 148);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Chile', 'CL', 'CHL', 152);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('China', 'CN', 'CHN', 156);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Colombia', 'CO', 'COL', 170);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Comoros', 'KM', 'COM', 174);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Congo, Democratic Republic of the', 'CD', 'COD', 180);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Congo, Republic of the', 'CG', 'COG', 178);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Costa Rica', 'CR', 'CRI', 188);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Croatia', 'HR', 'HRV', 191);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Cuba', 'CU', 'CUB', 192);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Cyprus', 'CY', 'CYP', 196);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Czech Republic', 'CZ', 'CZE', 203);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Denmark', 'DK', 'DNK', 208);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Djibouti', 'DJ', 'DJI', 262);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Dominica', 'DM', 'DMA', 212);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Dominican Republic', 'DO', 'DOM', 214);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Ecuador', 'EC', 'ECU', 218);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Egypt', 'EG', 'EGY', 818);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('El Salvador', 'SV', 'SLV', 222);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Equatorial Guinea', 'GQ', 'GNQ', 226);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Eritrea', 'ER', 'ERI', 232);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Estonia', 'EE', 'EST', 233);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Eswatini', 'SZ', 'SWZ', 748);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Ethiopia', 'ET', 'ETH', 231);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Fiji', 'FJ', 'FJI', 242);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Finland', 'FI', 'FIN', 246);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('France', 'FR', 'FRA', 250);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Gabon', 'GA', 'GAB', 266);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Gambia', 'GM', 'GMB', 270);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Georgia', 'GE', 'GEO', 268);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Germany', 'DE', 'DEU', 276);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Ghana', 'GH', 'GHA', 288);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Greece', 'GR', 'GRC', 300);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Grenada', 'GD', 'GRD', 308);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Guatemala', 'GT', 'GTM', 320);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Guinea', 'GN', 'GIN', 324);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Guinea-Bissau', 'GW', 'GNB', 624);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Guyana', 'GY', 'GUY', 328);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Haiti', 'HT', 'HTI', 332);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Honduras', 'HN', 'HND', 340);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Hungary', 'HU', 'HUN', 348);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Iceland', 'IS', 'ISL', 352);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('India', 'IN', 'IND', 356);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Indonesia', 'ID', 'IDN', 360);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Iran', 'IR', 'IRN', 364);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Iraq', 'IQ', 'IRQ', 368);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Ireland', 'IE', 'IRL', 372);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Israel', 'IL', 'ISR', 376);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Italy', 'IT', 'ITA', 380);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Jamaica', 'JM', 'JAM', 388);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Japan', 'JP', 'JPN', 392);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Jordan', 'JO', 'JOR', 400);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Kazakhstan', 'KZ', 'KAZ', 398);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Kenya', 'KE', 'KEN', 404);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Kiribati', 'KI', 'KIR', 296);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Korea, North', 'KP', 'PRK', 408);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Korea, South', 'KR', 'KOR', 410);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Kuwait', 'KW', 'KWT', 414);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Kyrgyzstan', 'KG', 'KGZ', 417);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Laos', 'LA', 'LAO', 418);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Latvia', 'LV', 'LVA', 428);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Lebanon', 'LB', 'LBN', 422);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Lesotho', 'LS', 'LSO', 426);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Liberia', 'LR', 'LBR', 430);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Libya', 'LY', 'LBY', 434);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Liechtenstein', 'LI', 'LIE', 438);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Lithuania', 'LT', 'LTU', 440);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Luxembourg', 'LU', 'LUX', 442);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Madagascar', 'MG', 'MDG', 450);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Malawi', 'MW', 'MWI', 454);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Malaysia', 'MY', 'MYS', 458);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Maldives', 'MV', 'MDV', 462);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Mali', 'ML', 'MLI', 466);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Malta', 'MT', 'MLT', 470);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Marshall Islands', 'MH', 'MHL', 584);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Mauritania', 'MR', 'MRT', 478);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Mauritius', 'MU', 'MUS', 480);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Mexico', 'MX', 'MEX', 484);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Micronesia', 'FM', 'FSM', 583);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Moldova', 'MD', 'MDA', 498);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Monaco', 'MC', 'MCO', 492);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Mongolia', 'MN', 'MNG', 496);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Montenegro', 'ME', 'MNE', 499);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Morocco', 'MA', 'MAR', 504);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Mozambique', 'MZ', 'MOZ', 508);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Myanmar', 'MM', 'MMR', 104);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Namibia', 'NA', 'NAM', 516);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Nauru', 'NR', 'NRU', 520);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Nepal', 'NP', 'NPL', 524);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Netherlands', 'NL', 'NLD', 528);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('New Zealand', 'NZ', 'NZL', 554);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Nicaragua', 'NI', 'NIC', 558);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Niger', 'NE', 'NER', 562);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Nigeria', 'NG', 'NGA', 566);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('North Macedonia', 'MK', 'MKD', 807);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Norway', 'NO', 'NOR', 578);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Oman', 'OM', 'OMN', 512);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Pakistan', 'PK', 'PAK', 586);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Palau', 'PW', 'PLW', 585);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Panama', 'PA', 'PAN', 591);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Papua New Guinea', 'PG', 'PNG', 598);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Paraguay', 'PY', 'PRY', 600);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Peru', 'PE', 'PER', 604);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Philippines', 'PH', 'PHL', 608);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Poland', 'PL', 'POL', 616);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Portugal', 'PT', 'PRT', 620);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Qatar', 'QA', 'QAT', 634);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Romania', 'RO', 'ROU', 642);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Russia', 'RU', 'RUS', 643);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Rwanda', 'RW', 'RWA', 646);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Saint Kitts and Nevis', 'KN', 'KNA', 659);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Saint Lucia', 'LC', 'LCA', 662);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Saint Vincent and the Grenadines', 'VC', 'VCT', 670);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Samoa', 'WS', 'WSM', 882);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('San Marino', 'SM', 'SMR', 674);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Sao Tome and Principe', 'ST', 'STP', 678);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Saudi Arabia', 'SA', 'SAU', 682);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Senegal', 'SN', 'SEN', 686);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Serbia', 'RS', 'SRB', 688);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Seychelles', 'SC', 'SYC', 690);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Sierra Leone', 'SL', 'SLE', 694);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Singapore', 'SG', 'SGP', 702);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Slovakia', 'SK', 'SVK', 703);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Slovenia', 'SI', 'SVN', 705);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Solomon Islands', 'SB', 'SLB', 90);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Somalia', 'SO', 'SOM', 706);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('South Africa', 'ZA', 'ZAF', 710);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('South Sudan', 'SS', 'SSD', 728);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Spain', 'ES', 'ESP', 724);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Sri Lanka', 'LK', 'LKA', 144);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Sudan', 'SD', 'SDN', 729);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Suriname', 'SR', 'SUR', 740);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Sweden', 'SE', 'SWE', 752);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Switzerland', 'CH', 'CHE', 756);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Syria', 'SY', 'SYR', 760);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Taiwan', 'TW', 'TWN', 158);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Tajikistan', 'TJ', 'TJK', 762);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Tanzania', 'TZ', 'TZA', 834);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Thailand', 'TH', 'THA', 764);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Timor-Leste', 'TL', 'TLS', 626);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Togo', 'TG', 'TGO', 768);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Tonga', 'TO', 'TON', 776);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Trinidad and Tobago', 'TT', 'TTO', 780);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Tunisia', 'TN', 'TUN', 788);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Turkey', 'TR', 'TUR', 792);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Turkmenistan', 'TM', 'TKM', 795);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Tuvalu', 'TV', 'TUV', 798);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Uganda', 'UG', 'UGA', 800);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Ukraine', 'UA', 'UKR', 804);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('United Arab Emirates', 'AE', 'ARE', 784);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('United Kingdom', 'GB', 'GBR', 826);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('United States', 'US', 'USA', 840);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Uruguay', 'UY', 'URY', 858);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Uzbekistan', 'UZ', 'UZB', 860);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Vanuatu', 'VU', 'VUT', 548);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Vatican City', 'VA', 'VAT', 336);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Venezuela', 'VE', 'VEN', 862);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Vietnam', 'VN', 'VNM', 704);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Yemen', 'YE', 'YEM', 887);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Zambia', 'ZM', 'ZMB', 894);",
                                    "INSERT INTO TableCountry (Name, Code, ShortName, NumericCode) VALUES ('Zimbabwe', 'ZW', 'ZWE', 716);"
                                };

                                foreach (string strCountry in straCountries)
                                {
                                    xSQLiteCommand.CommandText = strCountry;
                                    iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
                                }
                            }
                        }

                        xSQLiteConnection.Close();        // Close the connection to the database
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }

        private static bool bCreateTableCity()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableCity (
                        Id          INTEGER PRIMARY KEY ASC AUTOINCREMENT
                                              UNIQUE
                                            NOT NULL,
                        Name        TEXT    NOT NULL,
                        Code        TEXT,
                        ShortName   TEXT,
                        NumericCode INTEGER,
                        FkCountryId INTEGER
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                        {
                            bReturnValue = true;
                            if (CommonProperty.prop_bIsOfflinePos)
                            {
                                string[] straCountries = new string[]
                                {
                                    "INSERT INTO TableCity (Name, Code, ShortName, NumericCode, FkCountryId) VALUES ('London', 'GB-LND', 'LDN', 1, 183);",
                                    "INSERT INTO TableCity (Name, Code, ShortName, NumericCode, FkCountryId) VALUES ('Manchester', 'GB-MAN', 'MAN', 2, 183);",
                                    "INSERT INTO TableCity (Name, Code, ShortName, NumericCode, FkCountryId) VALUES ('Birmingham', 'GB-BIR', 'BHM', 3, 183);",
                                    "INSERT INTO TableCity (Name, Code, ShortName, NumericCode, FkCountryId) VALUES ('Liverpool', 'GB-LIV', 'LIV', 4, 183);",
                                    "INSERT INTO TableCity (Name, Code, ShortName, NumericCode, FkCountryId) VALUES ('Leeds', 'GB-LDS', 'LDS', 5, 183);",
                                    "INSERT INTO TableCity (Name, Code, ShortName, NumericCode, FkCountryId) VALUES ('Sheffield', 'GB-SHF', 'SHF', 6, 183);",
                                    "INSERT INTO TableCity (Name, Code, ShortName, NumericCode, FkCountryId) VALUES ('Bristol', 'GB-BST', 'BRS', 7, 183);",
                                    "INSERT INTO TableCity (Name, Code, ShortName, NumericCode, FkCountryId) VALUES ('Newcastle upon Tyne', 'GB-NET', 'NCL', 8, 183);",
                                    "INSERT INTO TableCity (Name, Code, ShortName, NumericCode, FkCountryId) VALUES ('Nottingham', 'GB-NGM', 'NTG', 9, 183);",
                                    "INSERT INTO TableCity (Name, Code, ShortName, NumericCode, FkCountryId) VALUES ('Southampton', 'GB-STH', 'SOU', 10, 183);"
                                };

                                foreach (string strCountry in straCountries)
                                {
                                    xSQLiteCommand.CommandText = strCountry;
                                    iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
                                }
                            }
                        }

                        xSQLiteConnection.Close();        // Close the connection to the database
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }

        private static bool bCreateTableDistrict()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableDistrict (
                        Id          INTEGER PRIMARY KEY ASC AUTOINCREMENT
                                              UNIQUE
                                            NOT NULL,
                        Name        TEXT    NOT NULL,
                        Code        TEXT,
                        ShortName   TEXT,
                        NumericCode INTEGER,
                        FkCityId    INTEGER
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                        {
                            bReturnValue = true;
                            if (CommonProperty.prop_bIsOfflinePos)
                            {
                                string[] straCountries = new string[]
                                {
                                    "INSERT INTO TableDistrict (Name, Code, ShortName, NumericCode, FkCityId) VALUES ('LDN-CMD', 'Camden', 'CMD', 1, 1);",
                                    "INSERT INTO TableDistrict (Name, Code, ShortName, NumericCode, FkCityId) VALUES ('LDN-WSTM', 'Westminster', 'WSTM', 2, 1);",
                                    "INSERT INTO TableDistrict (Name, Code, ShortName, NumericCode, FkCityId) VALUES ('LDN-KNS', 'Kensington and Chelsea', 'KNS', 3, 1);",
                                    "INSERT INTO TableDistrict (Name, Code, ShortName, NumericCode, FkCityId) VALUES ('LDN-HCK', 'Hackney', 'HCK', 4, 1);",
                                    "INSERT INTO TableDistrict (Name, Code, ShortName, NumericCode, FkCityId) VALUES ('LDN-ISL', 'Islington', 'ISL', 5, 1);",
                                    "INSERT INTO TableDistrict (Name, Code, ShortName, NumericCode, FkCityId) VALUES ('LDN-SWT', 'Southwark', 'SWT', 6, 1);",
                                    "INSERT INTO TableDistrict (Name, Code, ShortName, NumericCode, FkCityId) VALUES ('LDN-LMB', 'Lambeth', 'LMB', 7, 1);",
                                    "INSERT INTO TableDistrict (Name, Code, ShortName, NumericCode, FkCityId) VALUES ('LDN-WND', 'Wandsworth', 'WND', 8, 1);",
                                    "INSERT INTO TableDistrict (Name, Code, ShortName, NumericCode, FkCityId) VALUES ('LDN-TWH', 'Tower Hamlets', 'TWH', 9, 1);",
                                    "INSERT INTO TableDistrict (Name, Code, ShortName, NumericCode, FkCityId) VALUES ('LDN-HGY', 'Haringey', 'HGY', 10, 1);"
                                };

                                foreach (string strCountry in straCountries)
                                {
                                    xSQLiteCommand.CommandText = strCountry;
                                    iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
                                }
                            }
                        }

                        xSQLiteConnection.Close();        // Close the connection to the database
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }

        private static bool bCreateTableCurrency()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableCurrency (
                        Id             INTEGER PRIMARY KEY
                                               UNIQUE
                                               NOT NULL,
                        No             INTEGER,
                        Name           TEXT,
                        RateOfCurrency INTEGER,
                        CurrencyCode   INTEGER,
                        Sign           TEXT,
                        SignDirection  TEXT,
                        CurrencySymbol TEXT
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                        {
                            bReturnValue = true;
                            if (CommonProperty.prop_bIsOfflinePos)
                            {
                                string[] straQueries = new string[]
                                {
                                };

                                foreach (string strQuery in straQueries)
                                {
                                    xSQLiteCommand.CommandText = strQuery;
                                    iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
                                }
                            }
                        }

                        xSQLiteConnection.Close();        // Close the connection to the database
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }

        private static bool bCreateTableForm()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableForm (
                        Id                 INTEGER PRIMARY KEY ASC AUTOINCREMENT
                                                   UNIQUE
                                                   NOT NULL,
                        FormNo             INTEGER NOT NULL,
                        Name               TEXT    NOT NULL,
                        Function           TEXT    NOT NULL,
                        NeedLogin          BOOLEAN DEFAULT (0),
                        NeedAuth           BOOLEAN DEFAULT (0),
                        Width              INTEGER DEFAULT (1024),
                        Height             INTEGER DEFAULT (768),
                        FormBorderStyle    TEXT    DEFAULT ('SINGLE'),
                        StartPosition      TEXT    DEFAULT ('CENTERSCREEN'),
                        Caption            TEXT,
                        Icon               TEXT,
                        Image              TEXT,
                        BackColor          TEXT    DEFAULT ('AliceBlue'),
                        ShowStatusBar      BOOLEAN DEFAULT (1),
                        ShowInTaskbar      BOOLEAN DEFAULT (1),
                        UseVirtualKeyboard BOOLEAN DEFAULT (1) 
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                        {
                            bReturnValue = true;
                            if (CommonProperty.prop_bIsOfflinePos)
                            {
                                string[] straQueries = new string[]
                                {
                                    "INSERT INTO TableForm (FormNo, Name, Function, NeedLogin, NeedAuth, Caption, BackColor, ShowInTaskbar, UseVirtualKeyboard) VALUES (1, 'LOGIN', 'LOGIN', 0, 0, 'LOGIN', 'MidnightBlue', 0, 0);",
                                    "INSERT INTO TableForm (FormNo, Name, Function, NeedLogin, NeedAuth, Caption, BackColor, ShowInTaskbar, UseVirtualKeyboard) VALUES (2, 'SALE', 'SALE', 1, 0, 'SALE', 'MidnightBlue', 0, 0);",

                                };

                                foreach (string strQuery in straQueries)
                                {
                                    xSQLiteCommand.CommandText = strQuery;
                                    iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
                                }
                            }
                        }

                        xSQLiteConnection.Close();        // Close the connection to the database
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }

        private static bool bCreateTableFormControl()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableFormControl (
                        Id                   INTEGER PRIMARY KEY ASC AUTOINCREMENT
                                                     UNIQUE
                                                     NOT NULL,
                        FkFormId             INTEGER NOT NULL,
                        FkParentId           INTEGER,
                        Name                 TEXT    NOT NULL,
                        ParentName           TEXT,
                        FormControlFunction1 TEXT    NOT NULL,
                        FormControlFunction2 TEXT,
                        TypeNo               INTEGER,
                        Type                 TEXT    DEFAULT ('NOTYPE'),
                        Width                INTEGER NOT NULL,
                        Height               INTEGER NOT NULL,
                        LocationX            INTEGER NOT NULL,
                        LocationY            INTEGER NOT NULL,
                        StartPosition        TEXT,
                        Caption1             TEXT,
                        Caption2             TEXT,
                        List                 TEXT,
                        Dock                 TEXT,
                        Alignment            TEXT,
                        TextAlignment        TEXT    DEFAULT ('LEFT'),
                        CharacterCasing      TEXT    DEFAULT ('NORMAL'),
                        Font                 TEXT    DEFAULT ('Tahoma'),
                        Icon                 TEXT,
                        ToolTip              TEXT,
                        Image                TEXT,
                        ImageSelected        TEXT,
                        FontAutoHeight       BOOLEAN DEFAULT (1),
                        FontSize             REAL    DEFAULT (0),
                        InputType            TEXT    DEFAULT ('NUMERIC'),
                        TextImageRelation    TEXT    DEFAULT ('Overlay'),
                        BackColor            TEXT    DEFAULT ('Gray'),
                        ForeColor            TEXT    DEFAULT ('Black'),
                        KeyboardValue        TEXT
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                        {
                            bReturnValue = true;
                            if (CommonProperty.prop_bIsOfflinePos)
                            {
                                string[] straQueries = new string[]
                                {
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (1, 0, 'CASHIER_NAME_LIST', 'NONE', NULL, 3, 'COMBOBOX', 400, 50, 312, 100, NULL, NULL, NULL, NULL, NULL, NULL, 'LEFT', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 1, 0, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (1, 0, 'PASSWORD', 'NONE', NULL, 2, 'TEXTBOX', 400, 50, 312, 150, NULL, NULL, NULL, NULL, NULL, NULL, 'LEFT', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 1, 0, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (1, 0, 'LOGIN', 'LOGIN', NULL, 1, 'BUTTON', 200, 100, 412, 220, NULL, 'LOGIN', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 1, 0, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",

                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'SALESLIST', 'SALE_OPTION', NULL, 4, 'SALESLIST', 755, 250, 252, 1, NULL, '', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 1, 0, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'NUMPAD', 'SALE_PLU_BARCODE', NULL, 5, 'NUMPAD', 230, 298, 778, 404, NULL, '', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 1, 0, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'PAYMENTLIST', 'PAYMENTLIST', NULL, 6, 'PAYMENTLIST', 230, 298, 547, 404, NULL, '', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 1, 0, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'AMOUNTSTABLE', 'AMOUNTSTABLE', NULL, 7, 'AMOUNTSTABLE', 250, 200, 1, 1, NULL, '', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 1, 0, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'EXIT', 'EXIT_APPLICATION', NULL, 1, 'BUTTON', 100, 100, 1, 404, NULL, 'EXIT', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 0, 12, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'CLOSURE', 'CLOSURE', NULL, 1, 'BUTTON', 100, 100, 1, 603, NULL, 'CLOSURE', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 0, 12, 'ALPHANUMERIC', NULL, 'RED', 'WHITE', NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'DEPARTMENT1', 'SALE_DEPARTMENT', NULL, 1, 'BUTTON', 100, 100, 1, 202, NULL, 'MISCELLANEOUS', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 0, 12, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'PLU1', 'SALE_PLU_CODE', NULL, 1, 'BUTTON', 100, 100, 1, 303, NULL, '', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 0, 12, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'PLU5449000000996', 'SALE_PLU_BARCODE', NULL, 1, 'BUTTON', 100, 100, 321, 250, NULL, '', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 0, 12, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'PLU0746817004304', 'SALE_PLU_BARCODE', NULL, 1, 'BUTTON', 100, 100, 421, 250, NULL, '', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 0, 12, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'PAYMENT', 'CASH_PAYMENT', NULL, 1, 'BUTTON', 150, 187, 396, 404, NULL, 'CASH', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 0, 12, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'PAYMENT', 'CREDIT_PAYMENT', NULL, 1, 'BUTTON', 150, 110, 396, 592, NULL, 'CREDIT CARD', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 0, 12, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'CASH2000', 'CASH_PAYMENT', NULL, 1, 'BUTTON', 150, 98, 245, 404, NULL, '20 £', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 0, 12, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'CASH5000', 'CASH_PAYMENT', NULL, 1, 'BUTTON', 150, 99, 245, 503, NULL, '50 £', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 0, 12, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                    "INSERT INTO TableFormControl (FkFormId, FkParentId, Name, FormControlFunction1, FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue) VALUES (2, 0, 'CASH10000', 'CASH_PAYMENT', NULL, 1, 'BUTTON', 150, 99, 245, 603, NULL, '100 £', NULL, NULL, NULL, NULL, 'CENTER', 'UPPER', 'Tahoma', NULL, NULL, NULL, NULL, 0, 12, 'ALPHANUMERIC', NULL, NULL, NULL, NULL);",
                                };

                                foreach (string strQuery in straQueries)
                                {
                                    xSQLiteCommand.CommandText = strQuery;
                                    iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
                                }
                            }
                        }

                        xSQLiteConnection.Close();        // Close the connection to the database
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }

        private static bool bCreateTableLabelValue()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableLabelValue (
                        Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                        Key         TEXT,
                        Value       TEXT,
                        CultureInfo TEXT
                    );
                    ";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                        {
                            bReturnValue = true;
                            if (CommonProperty.prop_bIsOfflinePos)
                            {
                                string[] straQueries = new string[]
                                {
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('ReceiptNo', 'Receipt No', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CurrencySymbol', '£', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('Quantity', 'Quantity', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('FunctionNotDefined', 'Function not defined!', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('LicenseOwner', 'Licensee', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('AreYouSure', 'Are you sure?', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('Cashier', 'Cashier', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('DepartmentNotFound', 'Department not found.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CanNotInsertTransactıon', 'Can not insert transactıon.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CanNotStartReceipt', 'Can not start receipt.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('NeedCashierLogin', 'You need cashier login.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CashierLoginFailed', 'The login criteria may be incorrect, the operation failed.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('PluNotFound', 'Product not found.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('InsufficientStock', 'Insufficient Stock.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CanNotCloseReceipt', 'Can not Close Receipt.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('PaymentTypeError', 'Payment Type Error.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('PaymentNotPossible', 'Payment Is Not Possible.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CanNotCancelTransaction', 'Can not Cancel Transaction.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CanNotCancelDocument', 'Can not Cancel Document.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('SubtotalNotPossible', 'Subtotal Is Not Possible.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('SuspendQueueFull', 'Suspend Queue Is Full.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('SuspendNotFull', 'Suspend Is Not Full.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('NeedSuspend', 'Need Suspend.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('ClosureNotPossible', 'Closure is not possible', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('Price', 'Price', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('GroupNo', 'Group No', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('ProductSale', 'Sale', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('ProductReturn', 'Return', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('Waybill', 'Waybill', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('DeliveryNote', 'Delivery Note', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('Invoice', 'Invoice', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('Return', 'Return', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('FiscalReceipt', 'Receipt', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('NoneFiscalReceipt', 'Receipt', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('EInvoice', 'Electronic Invoice', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('EArchiveInvoice', 'Electronic Receipt', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('DiplomaticInvoice', 'Diplomatic Invoice', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CashOutflow', 'Cash Outflow', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CashInflow', 'Cash Inflow', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('SelfBillingInvoice', 'Self-Billing Invoice', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('PasswordCode', 'Password Code', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('DefinitionIsNotProper', 'The definition is not appropriate.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('LoginFailed', 'Login Failed', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('ProcessFinished', 'Process Finished', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('WrongPrice', 'Wrong Price', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('NotPossible', 'Is not possible.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CreditCardPaymentError', 'An error occurred with the credit card payment.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CancelInvoicePrint', 'Document printing was canceled.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CancelWaybillPrint', 'Waybill printing was canceled.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CancelDeliveryNotePrint', 'Delivery note printing was canceled.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CancelReturnPrint', 'Return invoice printing was canceled.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('DefineDiscountSurchargeValue', 'Define Discount and Surcharge Value.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('WrongQuantity', 'Wrong Quantity', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('Vat', 'Vat', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('PeriodicZReportWarning', 'Periodic Z Report Warning', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('DateAndTime', 'Date and Time', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('CashRegisterActivated', 'Cash Register Activated', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('OutOfService', 'Out of Service', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('ReceiptIsOpen', 'The receipt is open', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('ReceiptIsNotOpen', 'The receipt is not open', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('PaymentIsStarted', 'Payment is started', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('PaymentIsNotPossible', 'Payment is not possible', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('InsertPaper', 'Insert Paper', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('WaybillPrinted', 'Waybill Printed', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('DeliveryNotePrinted', 'Delivery Note Printed', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('InvoicePrinted', 'Invoice Printed', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('ReturnPrinted', 'Return Invoice Printed', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('PrintControl', 'Print Control', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('DiscountRate', 'Discount Rate', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('SurchargeRate', 'Surcharge Rate', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('DepartmentMaxWarning', 'Department Max Warning', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('DepartmentExistWarning', 'Department Exist Warning', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('PluMaxWarning', 'Plu Max Warning', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('PluExistWarning', 'Plu Exist Warning', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('PluGroupMaxWarning', 'Plu Group Max Warning', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('PluGroupExistWarning', 'Plu Group Exist Warning', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('VatSetError1', 'VAT must be between 1-99', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('VatSetError2', 'VAT Error', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('DocumentCancelled', 'Document Cancelled.', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('NetSale', 'NET SALE', 'en-GB');",
                                    "INSERT INTO TableLabelValue (Key, Value, CultureInfo) VALUES ('Change', 'CHANGE', 'en-GB');",

                                };

                                foreach (string strQuery in straQueries)
                                {
                                    xSQLiteCommand.CommandText = strQuery;
                                    iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
                                }
                            }
                        }

                        xSQLiteConnection.Close();        // Close the connection to the database
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }

        private static bool bCreateTablePaymentType()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TablePaymentType (
                        Id              INTEGER PRIMARY KEY ASC AUTOINCREMENT
                                                NOT NULL
                                                UNIQUE,
                        TypeNo          INTEGER NOT NULL,
                        TypeName        TEXT    NOT NULL,
                        CultureInfo     TEXT    NOT NULL,
                        TypeDescription TEXT
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                        {
                            bReturnValue = true;
                            if (CommonProperty.prop_bIsOfflinePos)
                            {
                                string[] straQueries = new string[]
                                {
                                    "INSERT INTO TablePaymentType (TypeNo, TypeName, CultureInfo) VALUES (1, 'Cash', 'en-GB');",                    // EnumPaymentType.CASH
                                    "INSERT INTO TablePaymentType (TypeNo, TypeName, CultureInfo) VALUES (2, 'Credit Card', 'en-GB');",             // EnumPaymentType.CREDIT_CARD
                                    "INSERT INTO TablePaymentType (TypeNo, TypeName, CultureInfo) VALUES (3, 'Check', 'en-GB');",                   // EnumPaymentType.CHECK
                                    "INSERT INTO TablePaymentType (TypeNo, TypeName, CultureInfo) VALUES (4, 'Credit', 'en-GB');",                  // EnumPaymentType.CREDIT_NOCARD
                                    "INSERT INTO TablePaymentType (TypeNo, TypeName, CultureInfo) VALUES (5, 'Prepaid Card', 'en-GB');",            // EnumPaymentType.PREPAID_CARD
                                    "INSERT INTO TablePaymentType (TypeNo, TypeName, CultureInfo) VALUES (6, 'Mobile', 'en-GB');",                  // EnumPaymentType.MOBILE
                                    "INSERT INTO TablePaymentType (TypeNo, TypeName, CultureInfo) VALUES (7, 'Bonus', 'en-GB');",                   // EnumPaymentType.BONUS
                                    "INSERT INTO TablePaymentType (TypeNo, TypeName, CultureInfo) VALUES (8, 'Foreign currency', 'en-GB');",        // EnumPaymentType.EXCHANGE
                                    "INSERT INTO TablePaymentType (TypeNo, TypeName, CultureInfo) VALUES (9, 'Payment on credit', 'en-GB');",       // EnumPaymentType.ON_CREDIT
                                    "INSERT INTO TablePaymentType (TypeNo, TypeName, CultureInfo) VALUES (10, 'Other', 'en-GB');",                  // EnumPaymentType.OTHER

                                };

                                foreach (string strQuery in straQueries)
                                {
                                    xSQLiteCommand.CommandText = strQuery;
                                    iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
                                }
                            }
                        }

                        xSQLiteConnection.Close();        // Close the connection to the database
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }

        private static bool bCreateTablePos()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TablePos (
                        Id                      INTEGER PRIMARY KEY ASC AUTOINCREMENT
                                                        UNIQUE
                                                        NOT NULL,
                        Name                    TEXT    NOT NULL,
                        SerialNumber            TEXT,
                        Brand                   TEXT,
                        Model                   TEXT,
                        OperatingSystemVersion  TEXT,
                        OwnerNationalIdNumber   TEXT,
                        OwnerTaxIdNumber        TEXT,
                        OwnerMersisIdNumber     TEXT,
                        OwnerCommercialRecordNo TEXT,
                        OwnerWebAdress          TEXT,
                        OwnerRegistrationNumber TEXT,
                        MacAddress              TEXT,
                        CashierScreenType       TEXT,
                        CustomerScreenType      TEXT,
                        CustomerDisplayType     TEXT,
                        CustomerDisplayPort     TEXT,
                        ReceiptPrinterType      TEXT,
                        ReceiptPrinterPortName  TEXT,
                        InvoicePrinterType      TEXT,
                        InvoicePrinterPortName  TEXT,
                        ScaleType               TEXT,
                        ScalePortName           TEXT,
                        BarcodeReaderPort       TEXT,
                        ServerIp1               TEXT,
                        ServerPort1             TEXT,
                        ServerIp2               TEXT,
                        ServerPort2             TEXT,
                        ForceToWorkOnline       INTEGER,
                        FkDefaultCountryId      INTEGER
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                        {
                            bReturnValue = true;
                            if (CommonProperty.prop_bIsOfflinePos)
                            {
                                xSQLiteCommand.CommandText = $"INSERT INTO TablePos (Name, SerialNumber, MacAddress, ForceToWorkOnline, FkDefaultCountryId) VALUES ('SaleFlex POS','{Api.GetDriveSerialNumber()}','{Api.GetMacAddress()}', 0, 183)";
                                iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
                            }
                        }

                        xSQLiteConnection.Close();        // Close the connection to the database
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }
    }
}
