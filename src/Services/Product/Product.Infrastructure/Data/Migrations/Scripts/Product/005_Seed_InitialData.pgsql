-- Copyright (c) 2025 - Jun Dev. All rights reserved

DO $$
BEGIN
  IF NOT EXISTS (SELECT 1 FROM Product WHERE productId = 'pro1') THEN
    INSERT INTO Product (
      ProductId, Name, Images, Address1, Address2, Address3, Address4,
      Price1, Price2, Price3, DisplayPrice, Status, DelFlg,
      Size1, Size2, Size3, TakeOverId, ShortDescription,
      Description, EmbeddedLink, RelatedGroupId,
      CreatedAt, CreatedBy, LastModified, LastModifiedBy
    ) VALUES (
      'pro1', 'Product 1', '', '', '', '', '',
      100.00, 200.00, 300.00, 0, 0, false,
      10.00, 20.00, 30.00, 'U000000001', 'Short description',
      'Description', '', '',
      CURRENT_TIMESTAMP, 'system', CURRENT_TIMESTAMP, 'system'
    );
  END IF;
END $$;