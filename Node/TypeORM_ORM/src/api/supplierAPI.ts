import express from 'express';
import { SupplierService } from '../bll/services/supplierService';

const router = express.Router();
const supplierService = new SupplierService();

router.get('/', async (req, res) => {
  try {
    const entities = await supplierService.getAll();
    res.status(200).json(entities);
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.get('/:id', async (req, res) => {
  const { id } = req.params;
  try {
    const entity = await supplierService.getById(Number(id));
    res.status(200).json(entity);
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.post('/', async (req, res) => {
  const entity = req.body;
  try {
    res.status(200).json(await supplierService.create(entity));
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.put('/:id', async (req, res) => {
  const entity = req.body;
  const { id } = req.params;
  try {
    res.status(200).json(await supplierService.update(Number(id), entity));
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.delete('/:id', async (req, res) => {
  const { id } = req.params;
  try {
    res.status(200).json(await supplierService.delete(Number(id)));
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

export default router;
