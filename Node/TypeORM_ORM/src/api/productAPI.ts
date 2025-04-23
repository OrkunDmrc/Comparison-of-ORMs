import express from 'express';
import { ProductService } from '../bll/services/productService';

const router = express.Router();
const productService = new ProductService();

router.get('/', async (req, res) => {
  try {
    const entities = await productService.getAll();
    res.status(200).json(entities);
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.get('/:id', async (req, res) => {
  const { id } = req.params;
  try {
    const entity = await productService.getById(Number(id));
    res.status(200).json(entity);
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.post('/', async (req, res) => {
  const entity = req.body;
  try {
    res.status(200).json(await productService.create(entity));
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.put('/:id', async (req, res) => {
  const entity = req.body;
  const { id } = req.params;
  try {
    res.status(200).json(await productService.update(Number(id), entity));
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.delete('/:id', async (req, res) => {
  const { id } = req.params;
  try {
    res.status(200).json(await productService.delete(Number(id)));
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

export default router;