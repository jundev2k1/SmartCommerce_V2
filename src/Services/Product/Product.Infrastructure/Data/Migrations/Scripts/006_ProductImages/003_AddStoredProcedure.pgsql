-- Copyright (c) 2025 - Jun Dev. All rights reserved

-- Query: Get product images by product_id
CREATE OR REPLACE FUNCTION sp_get_product_images_by_product_id(
  productId UUID
)
RETURNS SETOF product_images AS $$
BEGIN
  RETURN  QUERY
  SELECT  *
    FROM  product_images
   WHERE  product_id = productId;
END;
$$ LANGUAGE plpgsql;

-- Query: Get product images by product_id and optional type
CREATE OR REPLACE FUNCTION sp_get_product_images_by_type(
  productId UUID,
  imageType VARCHAR DEFAULT NULL
)
RETURNS SETOF product_images AS $$
BEGIN
  RETURN  QUERY
  SELECT  *
    FROM  product_images
   WHERE  product_id = productId
     AND  (
            imageType IS NULL
            OR
            type = imageType
          );
END;
$$ LANGUAGE plpgsql;


-- Command: Insert product image
CREATE OR REPLACE FUNCTION sp_insert_product_image(
  productId UUID,
  imageNo INT,
  url TEXT,
  type VARCHAR,
  altText TEXT,
  createdBy VARCHAR
)
RETURNS VOID AS $$
BEGIN
  INSERT INTO product_images (
    image_id,
    product_id,
    image_no,
    url,
    type,
    alt_text,
    created_at,
    created_by,
    last_modified,
    last_modified_by
  )
  VALUES (
    gen_random_uuid(),
    productId,
    imageNo,
    url,
    type,
    altText,
    CURRENT_TIMESTAMP,
    createdBy,
    CURRENT_TIMESTAMP,
    createdBy
  );
END;
$$ LANGUAGE plpgsql;

-- Command: Update product image
CREATE OR REPLACE FUNCTION sp_update_product_image(
  imageId UUID,
  imageNo INT,
  url TEXT,
  type VARCHAR,
  altText TEXT,
  lastModifiedBy VARCHAR
)
RETURNS VOID AS $$
BEGIN
  UPDATE  product_images
     SET  image_no = imageNo,
          url = url,
          type = type,
          alt_text = altText,
          last_modified = CURRENT_TIMESTAMP,
          last_modified_by = lastModifiedBy
   WHERE  image_id = imageId;
END;
$$ LANGUAGE plpgsql;

-- Command: Delete product image (hard delete)
CREATE OR REPLACE FUNCTION sp_delete_product_image(
  imageId UUID
)
RETURNS VOID AS $$
BEGIN
  DELETE FROM product_images
   WHERE image_id = imageId;
END;
$$ LANGUAGE plpgsql;
