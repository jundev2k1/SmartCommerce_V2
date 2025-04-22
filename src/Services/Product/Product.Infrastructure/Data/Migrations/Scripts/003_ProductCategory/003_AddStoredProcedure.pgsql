-- Copyright (c) 2025 - Jun Dev. All rights reserved

-- Query: Get all category for a product
CREATE OR REPLACE FUNCTION sp_get_all_category_for_product(
  productId UUID
)
RETURNS TABLE (
  product_id UUID,
  category_id VARCHAR(60),
  priority INT,
  valid_flg BOOLEAN,
  created_at TIMESTAMP,
  created_by VARCHAR(60),
  last_modified TIMESTAMP,
  last_modified_by VARCHAR(60)
) AS $$
BEGIN
  RETURN QUERY
    SELECT  product_id,
            category_id,
            priority,
            valid_flg,
            created_at,
            created_by,
            last_modified,
            last_modified_by
      FROM  product_category
     WHERE  product_id = productId;
END;
$$ LANGUAGE plpgsql;

-- Query: Get category by product ID and category ID
CREATE OR REPLACE FUNCTION sp_get_category_by_product_id(
  productId UUID,
  categoryId VARCHAR(60)
)
RETURNS TABLE (
  product_id UUID,
  category_id VARCHAR(60),
  priority INT,
  valid_flg BOOLEAN,
  created_at TIMESTAMP,
  created_by VARCHAR(60),
  last_modified TIMESTAMP,
  last_modified_by VARCHAR(60)
) AS $$
BEGIN
  RETURN QUERY
    SELECT  product_id,
            category_id,
            priority,
            valid_flg,
            created_at,
            created_by,
            last_modified,
            last_modified_by
      FROM  product_category
     WHERE  product_id = productId
       AND  category_id = categoryId;
END;
$$ LANGUAGE plpgsql;

-- Command: Insert product category
CREATE OR REPLACE FUNCTION sp_insert_product_category(
  productId UUID,
  categoryId VARCHAR(60),
  priority INT,
  validFlg BOOLEAN,
  createdBy VARCHAR(60)
)
RETURNS VOID AS $$  
BEGIN
  INSERT INTO product_category (
    product_id,
    category_id,
    priority,
    valid_flg,
    created_at,
    created_by,
    last_modified,
    last_modified_by
  )
  VALUES (
    productId,
    categoryId,
    priority,
    validFlg,
    CURRENT_TIMESTAMP,
    createdBy,
    CURRENT_TIMESTAMP,
    createdBy
  );
END;
$$ LANGUAGE plpgsql;

-- Command: Update product category
CREATE OR REPLACE FUNCTION sp_update_product_category(
  productId UUID,
  categoryId VARCHAR(60),
  priority INT,
  validFlg BOOLEAN,
  lastModifiedBy VARCHAR(60)
)
RETURNS VOID AS $$
BEGIN
  UPDATE  product_category
     SET  priority = priority,
          valid_flg = validFlg,
          last_modified = CURRENT_TIMESTAMP,
          last_modified_by = lastModifiedBy
   WHERE  product_id = productId
     AND  category_id = categoryId;
END;
$$ LANGUAGE plpgsql;

-- Command: Delete product category
CREATE OR REPLACE FUNCTION sp_delete_product_category(
  productId UUID,
  categoryId VARCHAR(60)
)
RETURNS VOID AS $$
BEGIN
  DELETE FROM product_category
   WHERE  product_id = productId
     AND  category_id = categoryId;
END;
$$ LANGUAGE plpgsql;
