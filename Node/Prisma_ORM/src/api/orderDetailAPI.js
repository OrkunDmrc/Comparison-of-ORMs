const express = require('express');
const OrderDetailService = require('../bll/services/orderDetailService');
const router = express.Router();

router.get('/', async (req, res) => {
  try {
    const entities = await OrderDetailService.getAll();
    res.status(200).json(entities);
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.get('/:orderID/:productID', async (req, res) => {
  const { orderID, productID } = req.query;
  try {
    const entity = await OrderDetailService.getById(Number(orderID), Number(productID));
    res.status(200).json(entity);
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.post('/', async (req, res) => {
  const entity = req.body;
  try {
    res.status(200).json(await OrderDetailService.create(entity));
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});


router.delete('/:orderID/:productID', async (req, res) => {
  const { orderID, productID } = req.params;
  try {
    res.status(200).json(await OrderDetailService.delete(Number(orderID), Number(productID)));
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

module.exports = router;
