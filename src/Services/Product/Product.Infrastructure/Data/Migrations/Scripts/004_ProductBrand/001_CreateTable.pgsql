-- Copyright (c) 2025 - Jun Dev. All rights reserved

CREATE TABLE IF NOT EXISTS product_brand (
  product_id UUID NOT NULL REFERENCES product(product_id) ON DELETE CASCADE,
  brand_id VARCHAR(60) NOT NULL,
  brand_no SMALLINT NOT NULL DEFAULT 0,
  is_primary BOOLEAN NOT NULL DEFAULT FALSE,
  valid_flg BOOLEAN NOT NULL DEFAULT TRUE,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  created_by VARCHAR(60) NOT NULL DEFAULT 'system',
  last_modified TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  last_modified_by VARCHAR(60) NOT NULL DEFAULT 'system',

  PRIMARY KEY (product_id, brand_id, brand_no)
);