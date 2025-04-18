-- ========================
-- Create Product Table
-- ========================

CREATE TABLE IF NOT EXISTS Product (
  BranchId VARCHAR(20) NOT NULL,
  ProductId VARCHAR(60) PRIMARY KEY,
  Name VARCHAR(255) NOT NULL,
  Images TEXT NOT NULL DEFAULT '',
  Address1 VARCHAR(60) NOT NULL DEFAULT '',
  Address2 VARCHAR(60) NOT NULL DEFAULT '',
  Address3 VARCHAR(60) NOT NULL DEFAULT '',
  Address4 VARCHAR(255) NOT NULL DEFAULT '',
  Price1 DECIMAL(18, 2) NOT NULL DEFAULT 0,
  Price2 DECIMAL(18, 2) NOT NULL DEFAULT 0,
  Price3 DECIMAL(18, 2) NOT NULL DEFAULT 0,
  DisplayPrice INT DEFAULT 0,
  Status INT DEFAULT 0,
  DelFlg BOOLEAN DEFAULT false,
  Size1 DECIMAL(18, 2) NOT NULL DEFAULT 0,
  Size2 DECIMAL(18, 2) NOT NULL DEFAULT 0,
  Size3 DECIMAL(18, 2) NOT NULL DEFAULT 0,
  TakeOverId VARCHAR(60) NOT NULL,
  ShortDescription TEXT NOT NULL DEFAULT '',
  Description TEXT NOT NULL DEFAULT '',
  EmbeddedLink TEXT NOT NULL DEFAULT '',
  RelatedGroupId TEXT NOT NULL DEFAULT '',
  CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  CreatedBy VARCHAR(60) NOT NULL DEFAULT 'system',
  LastModified TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  LastModifiedBy VARCHAR(60) NOT NULL DEFAULT 'system',
  SearchVector tsvector
);

-- ========================
-- Indexes
-- ========================

-- Create index for full-text search
CREATE INDEX  idx_product_searchvector 
          ON  Product USING GIN (SearchVector);

CREATE INDEX  idx_product_branch 
          ON  Product(BranchId) 
       WHERE  DelFlg = false;

CREATE INDEX  idx_product_created_date 
          ON  Product(DateCreated) 
       WHERE  DelFlg = false;

CREATE INDEX  idx_product_takeover 
          ON  Product(TakeOverId) 
       WHERE  DelFlg = false;

CREATE INDEX  idx_product_price1 
          ON  Product(Price1) 
       WHERE  DelFlg = false;

-- ========================
-- Triggers
-- ========================

-- Create trigger to update SearchVector on insert or update
CREATE FUNCTION product_searchvector_update()
RETURNS trigger AS $$
  BEGIN
    NEW.SearchVector := to_tsvector('simple', 
      coalesce(NEW.Name, '') || ' ' || coalesce(NEW.Description, '') || ' ' || coalesce(NEW.ShortDescription, ''));
    RETURN NEW;
  END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_update_searchvector
BEFORE INSERT OR UPDATE ON Product
FOR EACH ROW EXECUTE FUNCTION product_searchvector_update();

-- ========================
-- Procedure
-- ========================

-- Query: Get products
CREATE OR REPLACE FUNCTION sp_get_products(
  branchId VARCHAR,
  productIds VARCHAR[]
)
RETURNS SETOF Product AS $$
  BEGIN
    RETURN  QUERY
    SELECT  *
      FROM  Product
     WHERE  DelFlg = false
       AND  BranchId = branchId
       AND  ProductId = ANY(productIds);
  END;

-- Query: Get Product by ID
CREATE OR REPLACE FUNCTION sp_get_product_by_id(
  branchId VARCHAR,
  productId VARCHAR
)
RETURNS SETOF Product AS $$
  BEGIN
    RETURN  QUERY
    SELECT  *
      FROM  Product
     WHERE  DelFlg = false
       AND  BranchId = branchId
       AND  ProductId = productId;
  END;
$$ LANGUAGE plpgsql;

-- Command: Insert product
CREATE OR REPLACE FUNCTION sp_insert_product(
  branchId VARCHAR,
  productId VARCHAR,
  name VARCHAR,
  images VARCHAR,
  address1 VARCHAR,
  address2 VARCHAR,
  address3 VARCHAR,
  address4 VARCHAR,
  price1 DECIMAL,
  price2 DECIMAL,
  price3 DECIMAL,
  displayPrice INT,
  status INT,
  size1 DECIMAL,
  size2 DECIMAL,
  size3 DECIMAL,
  takeOverId VARCHAR,
  shortDescription VARCHAR,
  description TEXT,
  embeddedLink VARCHAR,
  relatedGroupId VARCHAR,
  categoryId1 VARCHAR,
  createdBy VARCHAR
)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Product (
    ProductId,
    BranchId,
    Name,
    Images,
    Address1,
    Address2,
    Address3,
    Address4,
    Price1,
    Price2,
    Price3,
    DisplayPrice,
    Status,
    DelFlg,
    Size1,
    Size2,
    Size3,
    TakeOverId,
    ShortDescription,
    Description,
    EmbeddedLink,
    RelatedGroupId,
    DateCreated,
    DateChanged,
    CreatedBy,
    LastChanged
  )
  VALUES (
    productId,
    branchId,
    name,
    images,
    address1,
    address2,
    address3,
    address4,
    price1,
    price2,
    price3,
    displayPrice,
    status,
    FALSE,
    size1,
    size2,
    size3,
    takeOverId,
    shortDescription,
    description,
    embeddedLink,
    relatedGroupId,
    CURRENT_TIMESTAMP,
    CURRENT_TIMESTAMP,
    createdBy,
    createdBy
  );
END;
$$ LANGUAGE plpgsql;

-- Command: Update product
CREATE OR REPLACE FUNCTION sp_update_product(
  branchId VARCHAR,
  productId VARCHAR,
  name VARCHAR,
  images VARCHAR,
  address1 VARCHAR,
  address2 VARCHAR,
  address3 VARCHAR,
  address4 VARCHAR,
  price1 DECIMAL,
  price2 DECIMAL,
  price3 DECIMAL,
  displayPrice INT,
  size1 DECIMAL,
  size2 DECIMAL,
  size3 DECIMAL,
  takeOverId VARCHAR,
  shortDescription VARCHAR,
  description TEXT,
  embeddedLink VARCHAR,
  relatedGroupId VARCHAR,
  status INT,
  lastChangedBy VARCHAR
)
RETURNS VOID AS $$
BEGIN
  UPDATE  Product
     SET  Name = name,
          Images = images,
          Address1 = address1,
          Address2 = address2,
          Address3 = address3,
          Address4 = address4,
          Price1 = price1,
          Price2 = price2,
          Price3 = price3,
          DisplayPrice = displayPrice,
          Size1 = size1,
          Size2 = size2,
          Size3 = size3,
          TakeOverId = takeOverId,
          shortDescription = shortDescription,
          Description = description,
          EmbeddedLink = embeddedLink,
          RelatedGroupId = relatedGroupId,
          Status = status,
          DateChanged = CURRENT_TIMESTAMP,
          LastChanged = lastChangedBy
   WHERE  DelFlg = false
     AND  BrandId = branchId
     AND  ProductId = productId;
END;
$$ LANGUAGE plpgsql;

-- Command: Soft delete product
CREATE OR REPLACE FUNCTION sp_soft_delete_product(
  branchId VARCHAR,
  productId VARCHAR,
  changedBy VARCHAR
)
RETURNS VOID AS $$
  BEGIN
    UPDATE  Product
       SET  DelFlg = true,
            DateChanged = CURRENT_TIMESTAMP,
            LastChanged = changedBy
     WHERE  BrandId = branchId 
       AND  ProductId = productId;
  END;
$$ LANGUAGE plpgsql;
