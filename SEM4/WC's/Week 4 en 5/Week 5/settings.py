from pathlib import Path
from loguru import logger

class Settings():
    basedir = Path.cwd()
    rawdir = Path("raw_data")
    processeddir = Path("processed_data")
    logdir = basedir / "log"
    
    DB = {'servername': 'DESKTOP-P7DROCJ\\WINCCPLUSMIG2014',
      'database': 'datawarehouse'}

    export_conn = pypyodbc.connect('DRIVER={SQL Server};SERVER=' + DB['servername'] + ';DATABASE=' + DB['database'] + ';Trusted_Connection=yes')

    cursor = export_conn.cursor()

    go_sales = sqlite3.connect("C:\\Users\\Nick Frietman\\Desktop\\HC1\\go_sales.sqlite")
    go_staff = sqlite3.connect("C:\\Users\\Nick Frietman\\Desktop\\HC1\\go_staff.sqlite")
    go_crm = sqlite3.connect("C:\\Users\\Nick Frietman\\Desktop\\HC1\\go_crm.sqlite")
    inventory_forecast = pd.read_csv("C:\\Users\\Nick Frietman\\Desktop\\HC1\\GO_SALES_INVENTORY_LEVELSData.csv")
    product_forecast = pd.read_csv("C:\\Users\\Nick Frietman\\Desktop\\HC1\\GO_SALES_PRODUCT_FORECASTData.csv")

    sales_product = pd.read_sql_query("SELECT * FROM product", go_sales)
    product_type = pd.read_sql_query("SELECT * FROM product_type", go_sales)
    product_line = pd.read_sql_query("SELECT * FROM product_line", go_sales)
    sales_staff = pd.read_sql_query("SELECT * FROM sales_staff", go_sales)
    sales_branch = pd.read_sql_query("SELECT * FROM sales_branch", go_sales)
    retailer_site = pd.read_sql_query("SELECT * FROM retailer_site", go_sales)
    sales_country = pd.read_sql_query("SELECT * FROM country", go_sales)
    order_header = pd.read_sql_query("SELECT * FROM order_header", go_sales)
    order_details = pd.read_sql_query("SELECT * FROM order_details", go_sales)
    sales_targetdata = pd.read_sql_query("SELECT * FROM SALES_TARGETData", go_sales)
    returned_item = pd.read_sql_query("SELECT * FROM returned_item", go_sales)
    return_reason = pd.read_sql_query("SELECT * FROM return_reason", go_sales)
    order_method = pd.read_sql_query("SELECT * FROM order_method", go_sales)

    satisfaction_type = pd.read_sql_query("SELECT * FROM satisfaction_type", go_staff)
    course =  pd.read_sql_query("SELECT * FROM course", go_staff)
    satisfaction =  pd.read_sql_query("SELECT * FROM satisfaction", go_staff)
    training =  pd.read_sql_query("SELECT * FROM training", go_staff)
    s_sales_staff =  pd.read_sql_query("SELECT * FROM sales_staff", go_staff)
    staff_sales_branch =  pd.read_sql_query("SELECT * FROM sales_branch", go_staff)

    retailer_contact = pd.read_sql_query("SELECT * FROM retailer_contact", go_crm)
    crm_retailer_site =  pd.read_sql_query("SELECT * FROM retailer_site", go_crm)
    sales_territory = pd.read_sql_query("SELECT * FROM sales_territory", go_crm)
    country = pd.read_sql_query("SELECT * FROM country", go_crm)
    retailer_headquarters = pd.read_sql_query("SELECT * FROM retailer_headquarters", go_crm)
    crm_retailer = pd.read_sql_query("SELECT * FROM retailer", go_crm)
    retailer_type = pd.read_sql_query("SELECT * FROM retailer_type", go_crm)
    sales_demographic = pd.read_sql_query("SELECT * FROM sales_demographic", go_crm)
    retailer_segment = pd.read_sql_query("SELECT * FROM retailer_segment", go_crm)
    age_group = pd.read_sql_query("SELECT * FROM age_group", go_crm)

settings = Settings()
logger.add("logfile.log")