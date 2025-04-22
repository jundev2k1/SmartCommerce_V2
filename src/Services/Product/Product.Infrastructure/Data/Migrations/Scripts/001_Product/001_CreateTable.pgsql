-- Copyright (c) 2025 - Jun Dev. All rights reserved

CREATE TABLE IF NOT EXISTS product (
  product_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  sku VARCHAR(60) NOT NULL DEFAULT '',
  name VARCHAR(255) NOT NULL,
  price DECIMAL(18, 2) NOT NULL DEFAULT 0,
  special_price DECIMAL(18, 2) NOT NULL DEFAULT 0,
  cost_price DECIMAL(18, 2) NOT NULL DEFAULT 0,
  rating DECIMAL(3, 2) NOT NULL DEFAULT 0,
  total_previews INT NOT NULL DEFAULT 0,
  display_start TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  display_end TIMESTAMP,
  attributes JSONB DEFAULT '{}',
  short_description TEXT NOT NULL DEFAULT '',
  description TEXT NOT NULL DEFAULT '',
  slug VARCHAR(255) NOT NULL DEFAULT '',
  valid_flg BOOLEAN DEFAULT TRUE,
  del_flg BOOLEAN DEFAULT FALSE,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  created_by VARCHAR(60) NOT NULL DEFAULT 'system',
  last_modified TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  last_modified_by VARCHAR(60) NOT NULL DEFAULT 'system',
  search_vector tsvector
);
