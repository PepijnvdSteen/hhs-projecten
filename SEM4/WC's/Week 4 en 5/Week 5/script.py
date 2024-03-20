# %%
import pandas as pd
import pypyodbc
import sqlite3
from settings import Settings


# %% [markdown]
# <h1>Plaatsen van Dimensies in database</h1>

# %% [markdown]
# <h2>Staff_sales_staff</h2>

# %% [markdown]
# <b>Injecteren in datawarehouse</b>

# %%
staff_sales_staff = pd.merge(s_sales_staff, pd.merge(staff_sales_branch, sales_country, how='left', left_on='COUNTRY_CODE', right_on='COUNTRY_CODE'), how='left', left_on='SALES_BRANCH_CODE', right_on='SALES_BRANCH_CODE')
staff_sales_staff.drop(columns=['TRIAL633_x', 'TRIAL633_y', 'TRIAL879'])

for index, row in staff_sales_staff.iterrows():
    try:
        query = f"INSERT INTO STAFF_SALES_STAFF VALUES ({row['SALES_STAFF_CODE']}, '{row['FIRST_NAME']}', '{row['LAST_NAME']}', '{row['POSITION_EN']}', '{row['WORK_PHONE']}', '{row['EXTENSION']}', '{row['FAX']}', '{row['EMAIL']}', '{row['DATE_HIRED']}', {row['SALES_BRANCH_CODE']}, '{row['MANAGER_CODE']}', '{row['ADDRESS1']}', '{row['ADDRESS2']}', '{row['CITY']}', '{row['REGION']}', '{row['POSTAL_ZONE']}', {row['COUNTRY_CODE']}, '{row['COUNTRY']}', '{row['LANGUAGE']}', '{row['CURRENCY_NAME']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()

# %% [markdown]
# <b>Suggeraatsleutel en timestamp toevoegen</b>

# %%
try:
    query = f"ALTER TABLE staff_sales_staff ADD SK_date INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()


# %% [markdown]
# <h2>Satisfaction_type</h2>

# %% [markdown]
# <b>Injecteren in datawarehouse</b>

# %%
satisfaction_type.drop(columns='TRIAL633')

for index, row in satisfaction_type.iterrows():
    try:
        query = f"INSERT INTO SATISFACTION_TYPE VALUES ({row['SATISFACTION_TYPE_CODE']}, '{row['SATISFACTION_TYPE_DESCRIPTION']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()

# %% [markdown]
# <b>Suggeraatsleutel en timestamp toevoegen</b>

# %%
try:
    query = f"ALTER TABLE satisfaction_type ADD SK_date INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()

# %% [markdown]
# <h2>Retailer</h2>

# %%
retailer = pd.merge(pd.merge(crm_retailer, retailer_type, how='left', left_on='RETAILER_TYPE_CODE', right_on='RETAILER_TYPE_CODE'), pd.merge(retailer_headquarters, retailer_segment, how='left', left_on='SEGMENT_CODE', right_on='SEGMENT_CODE'), how='left', left_on='RETAILER_CODEMR', right_on='RETAILER_CODEMR')
retailer.drop(columns=['TRIAL219', 'TRIAL222', 'TRIAL222_x', 'TRIAL222_y'])

for index, row in retailer.iterrows():
    try:
        query = f"INSERT INTO RETAILER VALUES ({row['RETAILER_CODE']}, '{row['RETAILER_CODEMR']}', '{row['COMPANY_NAME']}', {row['RETAILER_TYPE_CODE']}, '{row['RETAILER_TYPE_EN']}', '{row['RETAILER_NAME']}', '{row['ADDRESS1']}', '{row['ADDRESS2']}', '{row['CITY']}', '{row['REGION']}', '{row['POSTAL_ZONE']}', '{row['COUNTRY_CODE']}', '{row['PHONE']}', '{row['FAX']}', '{row['SEGMENT_CODE']}', '{row['LANGUAGE']}', '{row['SEGMENT_NAME']}', '{row['SEGMENT_DESCRIPTION']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()

# %% [markdown]
# <b>Suggeraatsleutel en timestamp toevoegen</b>

# %%
try:
    query = f"ALTER TABLE retailer ADD SK_date INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()

# %% [markdown]
# <h2>Return_reason</h2>

# %% [markdown]
# <b>Injecteren in datawarehouse</b>

# %%
return_reason
for index, row in return_reason.iterrows():
    try:
        query = f"INSERT INTO RETURN_REASON VALUES ({row['RETURN_REASON_CODE']}, '{row['RETURN_DESCRIPTION_EN']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()

# %% [markdown]
# <b>Suggeraatsleutel en timestamp toevoegen</b>

# %%
try:
    query = f"ALTER TABLE return_reason ADD SK_date INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()

# %% [markdown]
# <h2>Sales_Retailer_Site</h2>

# %% [markdown]
# <b>Injecteren in datawarehouse</b>

# %%
for index, row in sales_retailer_site.iterrows():
    try:
        query = f"INSERT INTO SALES_RETAILER_SITE VALUES ({row['RETAILER_SITE_CODE']}, {row['RETAILER_CODE']}, '{row['ADDRESS1']}', '{row['ADDRESS2']}', '{row['CITY']}', '{row['REGION']}', '{row['POSTAL_ZONE']}', {row['COUNTRY_CODE']}, '{row['ACTIVE_INDICATOR']}', '{row['COUNTRY']}', '{row['LANGUAGE']}', '{row['CURRENCY_NAME']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()

# %% [markdown]
# <b>Surrogaatsleutel en timestamp toevoegen</b>
# 

# %%
try:
    query = "ALTER TABLE SALES_RETAILER_SITE ADD SK_sales_retailer_site INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()

# %% [markdown]
# <h2>Course</h2>

# %% [markdown]
# <b>Injecteren in datawarehouse</b>

# %%
course.drop(columns='TRIAL633')
course
for index, row in course.iterrows():
    try:
        query = f"INSERT INTO course VALUES ({row['COURSE_CODE']}, '{row['COURSE_DESCRIPTION']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()
        

# %% [markdown]
# <b>Surrogaatsleutel en timestamp toevoegen</b>

# %%
try:
    query = f"ALTER TABLE course ADD SK_sales_targetdata INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()

# %% [markdown]
# <h2>Product</h2>

# %% [markdown]
# <b>Injecteren in datawarehouse</b>

# %%
product = pd.merge(sales_product, pd.merge(product_type, product_line, how='left', left_on='PRODUCT_LINE_CODE', right_on='PRODUCT_LINE_CODE'), how='left', left_on='PRODUCT_TYPE_CODE', right_on='PRODUCT_TYPE_CODE')
product
for index, row in product.iterrows():
    try:
        query = f"INSERT INTO PRODUCT VALUES ({row['PRODUCT_NUMBER']}, '{row['INTRODUCTION_DATE']}', {row['PRODUCT_TYPE_CODE']}, '{row['PRODUCTION_COST']}', '{row['MARGIN']}', '{row['PRODUCT_IMAGE']}', '{row['LANGUAGE']}', '{row['PRODUCT_NAME']}', '{row['DESCRIPTION']}', {row['PRODUCT_LINE_CODE']}, '{row['PRODUCT_TYPE_EN']}', '{row['PRODUCT_LINE_EN']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close() 

# %% [markdown]
# <b>Surrogaatsleutel en timestamp toevoegen</b>

# %%
try:
    query = f"ALTER TABLE product ADD SK_sales_targetdata INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()

# %% [markdown]
# <h2>Order_method</h2>

# %% [markdown]
# <b>Injecteer in datawarehouse</b>

# %%
order_method

for index, row in order_method.iterrows():
    try:
        query = f"INSERT INTO ORDER_METHOD VALUES ({row['ORDER_METHOD_CODE']}, '{row['ORDER_METHOD_EN']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close() 

# %% [markdown]
# <b>Surrogaatsleutel en timestamp toevoegen</b>

# %%
try:
    query = f"ALTER TABLE order_method ADD SK_sales_targetdata INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()

# %% [markdown]
# <h2>Sales_sales_staff</h2>

# %% [markdown]
# <b>Injecteer in datawarehouse<b>

# %%
sales_sales_staff = pd.merge(sales_staff, pd.merge(sales_branch, sales_country, how='left', left_on='COUNTRY_CODE', right_on='COUNTRY_CODE'), how='left', left_on='SALES_BRANCH_CODE', right_on='SALES_BRANCH_CODE')
sales_sales_staff.drop(columns=['TRIAL888_x', 'TRIAL888_y'])
sales_sales_staff
for index, row in sales_sales_staff.iterrows():
    try:
        query = f"INSERT INTO SALES_SALES_STAFF VALUES ({row['SALES_STAFF_CODE']}, '{row['FIRST_NAME']}', '{row['LAST_NAME']}', '{row['POSITION_EN']}', '{row['WORK_PHONE']}', {row['EXTENSION']}, '{row['FAX']}', '{row['EMAIL']}', '{row['DATE_HIRED']}', {row['SALES_BRANCH_CODE']}, '{row['ADDRESS1']}', '{row['ADDRESS2']}', '{row['CITY']}', '{row['REGION']}', '{row['POSTAL_ZONE']}', {row['COUNTRY_CODE']}, '{row['COUNTRY']}', '{row['LANGUAGE']}', '{row['CURRENCY_NAME']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()

# %% [markdown]
# <b>Surrogaatsleutel en timestamp toevoegen</b>

# %%
try:
    query = f"ALTER TABLE sales_sales_staff ADD SK_sales_targetdata INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()

# %% [markdown]
# <h1>Plaatsen van Feiten in datawarehouse

# %% [markdown]
# <h2>Order_data</h2>

# %% [markdown]
# <b>Injecteren in database</b>

# %%
order_data = pd.merge(order_header, pd.merge(order_details, returned_item, how='left', left_on='ORDER_DETAIL_CODE', right_on='ORDER_DETAIL_CODE'), how='left', left_on='ORDER_NUMBER', right_on='ORDER_NUMBER')
order_data.drop(columns=['TRIAL885', 'TRIAL879', 'TRIAL888'])

for index, row in order_data.iterrows():
    try:
        query = f"INSERT INTO ORDER_DATA VALUES ({row['ORDER_NUMBER']}, '{row['RETAILER_NAME']}', {row['RETAILER_SITE_CODE']}, {row['RETAILER_CONTACT_CODE']}, {row['SALES_STAFF_CODE']}, {row['SALES_BRANCH_CODE']}, '{row['ORDER_DATE']}', {row['ORDER_METHOD_CODE']}, '{row['ORDER_DETAIL_CODE']}', '{row['QUANTITY']}', '{row['UNIT_COST']}', '{row['UNIT_PRICE']}', '{row['UNIT_SALE_PRICE']}', '{row['RETURN_CODE']}', '{row['RETURN_DATE']}', '{row['RETURN_REASON_CODE']}', '{row['RETURN_QUANTITY']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()

# %% [markdown]
# <b>Surrogaatsleutel en timestamp aanmaken</b>

# %%
try:
    query = f"ALTER TABLE ORDER_DATA ADD SK_order_data INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()


# %% [markdown]
# <h2>Sales_targetdata</h2>
# 

# %% [markdown]
# <b>Injecteren in database

# %%
sales_targetdata


for index, row in sales_targetdata.iterrows():
    try:
        query = f"INSERT INTO sales_targetdata VALUES ({row['Id']}, '{row['SALES_STAFF_CODE']}', '{row['SALES_YEAR']}', '{row['SALES_PERIOD']}', '{row['RETAILER_NAME']}', '{row['PRODUCT_NUMBER']}', '{row['SALES_TARGET']}', '{row['RETAILER_CODE']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()

# %% [markdown]
# <b>Surrogaatsleutel en timestamp aanmaken</b>

# %%
try:
    query = f"ALTER TABLE sales_targetdata ADD SK_sales_targetdata INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()


# %% [markdown]
# <h2>Date</h2>

# %% [markdown]
# <b>Injecteren in datawarehouse</b>

# %%
date = pd.DataFrame(columns=['DATE_YEAR','DATE_PERIOD', 'DATE_MONTH', 'DATE_DAY'])

for index, row in date.iterrows():
    try:
        query = f"INSERT INTO date VALUES ('{row['DATE_YEAR']}', '{row['DATE_PERIOD']}', '{row['DATE_MONTH']}', '{row['DATE_DAY']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()


# %% [markdown]
# <b>Surrogaatsleutel en timpstamp aanmaken</b>

# %%
try:
    query = f"ALTER TABLE date ADD SK_date INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()


# %% [markdown]
# <h2>Training</h2>

# %% [markdown]
# <b>Injecteren in datawarehouse</b>

# %%

training.drop(columns=['TRIAL633'])
training
for index, row in training.iterrows():
    try:
        query = f"INSERT INTO training VALUES ({row['YEAR']}, {row['SALES_STAFF_CODE']}, {row['COURSE_CODE']})"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()


# %% [markdown]
# <b>Surrogaatsleutel en timestamp aanmaken</b>
# 

# %%
try:
    query = f"ALTER TABLE training ADD SK_training INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()


# %% [markdown]
# <h2>Satisfaction</h2>
# 

# %% [markdown]
# <b>Injectren in datawarehouse</b>

# %%

for index, row in satisfaction.iterrows():
    try:
        query = f"INSERT INTO satisfaction VALUES ('{row['YEAR']}', {row['SALES_STAFF_CODE']}, {row['SATISFACTION_TYPE_CODE']})"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()

# %% [markdown]
# <b>Surrogaatsleutel en timestamp aanmaken</b>

# %%
try:
    query = f"ALTER TABLE satisfaction ADD SK_satisfaction INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()


# %% [markdown]
# <h2>Go_sales_inventory_forcastdata</h2>

# %% [markdown]
# <b>Injecteren in datawarehouse</b>

# %%


for index, row in inventory_forecast.iterrows():
    try:
        query = f"INSERT INTO GO_SALES_INVENTORY_FORECASTDATA VALUES ('{row['INVENTORY_YEAR']}', '{row['INVENTORY_MONTH']}', '{row['PRODUCT_NUMBER']}', '{row['INVENTORY_COUNT']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()

# %% [markdown]
# <b>Surrogaatsleutel en timestamp aanmaken</b>

# %%

try:
    query = f"ALTER TABLE GO_SALES_INVENTORY_FORECASTDATA ADD SK_GO_SALES_INVENTORY_FORECASTDATA INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()


# %% [markdown]
# <h2>Go_sales_product_forecastdata</h2>

# %% [markdown]
# <b>Injecteren in datawarehouse</b>

# %%


for index, row in product_forecast.iterrows():
    try:
        query = f"INSERT INTO GO_SALES_PRODUCT_FORECASTDATA VALUES ('{row['PRODUCT_NUMBER']}', '{row['YEAR']}', '{row['MONTH']}', '{row['EXPECTED_VOLUME']}')"
        cursor.execute(query)
    except pypyodbc.Error as e:
        print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()

# %% [markdown]
# <b>Surrogaatsleutel en timestamp aanmaken</b>

# %%
try:
    query = f"ALTER TABLE GO_SALES_PRODUCT_FORECASTDATA ADD SK_GO_SALES_PRODUCT_FORECASTDATA INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Timestamp DATETIME NOT NULL DEFAULT(GETDATE())"
    cursor.execute(query)
except pypyodbc.Error as e:
    print(f"Error inserting row {index}: {e}")

export_conn.commit()
cursor.close()


