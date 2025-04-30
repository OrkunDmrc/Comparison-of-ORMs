const express = require('express');
const OrderService = require('../bll/services/orderService');
const router = express.Router();

router.get('/AllTables', async (req, res) => {
  try {
    await OrderService.allTables();
    res.status(200).json("OK");
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.get('/', async (req, res) => {
  try {
    const entities = await OrderService.getAll();
    res.status(200).json(entities);
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.get('/:id', async (req, res) => {
  const { id } = req.params;
  try {
    const entity = await OrderService.getById(Number(id));
    res.status(200).json(entity);
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.post('/', async (req, res) => {
  const entity = req.body;
  try {
    res.status(200).json(await OrderService.create(entity));
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.put('/:id', async (req, res) => {
  const entity = req.body;
  const { id } = req.params;
  try {
    res.status(200).json(await OrderService.update(Number(id), entity));
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.delete('/:id', async (req, res) => {
  const { id } = req.params;
  try {
    res.status(200).json(await OrderService.delete(Number(id)));
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

module.exports = router;
