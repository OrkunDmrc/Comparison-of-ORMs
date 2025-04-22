const express = require('express');
const EmployeeTerritoryService = require('../bll/services/employeeTerritoryService');
const router = express.Router();

router.get('/', async (req, res) => {
  try {
    const entities = await EmployeeTerritoryService.getAll();
    res.status(200).json(entities);
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.get('/:id', async (req, res) => {
  const { id } = req.params;
  try {
    const entity = await EmployeeTerritoryService.getById(Number(id));
    res.status(200).json(entity);
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.post('/', async (req, res) => {
  const entity = req.body;
  try {
    res.status(200).json(await EmployeeTerritoryService.create(entity));
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.put('/:id', async (req, res) => {
  const entity = req.body;
  const { id } = req.params;
  try {
    res.status(200).json(await EmployeeTerritoryService.update(Number(id), entity));
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

router.delete('/:id', async (req, res) => {
  const { id } = req.params;
  try {
    res.status(200).json(await EmployeeTerritoryService.delete(Number(id)));
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

module.exports = router;
