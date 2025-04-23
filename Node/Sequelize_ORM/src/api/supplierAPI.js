const express = require('express');
const SupplierService = require('../bll/services/supplierService');
const router = express.Router();

router.get('/', async (req, res) => {
  try {
    const entities = await SupplierService.getAll();
    res.status(200).json(entities);
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.get('/:id', async (req, res) => {
  const { id } = req.params;
  try {
    const entity = await SupplierService.getById(Number(id));
    res.status(200).json(entity);
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.post('/', async (req, res) => {
  const entity = req.body;
  try {
    res.status(200).json(await SupplierService.create(entity));
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.put('/:id', async (req, res) => {
  const entity = req.body;
  const { id } = req.params;
  try {
    res.status(200).json(await SupplierService.update(Number(id), entity));
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.delete('/:id', async (req, res) => {
  const { id } = req.params;
  try {
    res.status(200).json(await SupplierService.delete(Number(id)));
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

module.exports = router;
