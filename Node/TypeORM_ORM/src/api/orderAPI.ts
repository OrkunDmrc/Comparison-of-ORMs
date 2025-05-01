import express from 'express';
import { OrderService } from '../bll/services/orderService';

const router = express.Router();
const orderService = new OrderService();

router.get('/AllTables', async (req, res) => {
  try {
    for(let i=0;i<20;i++){
      await orderService.allTables();
    }
    res.status(200).json("OK");
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.get('/', async (req, res) => {
  try {
    for(let i=0;i<19;i++){
      await orderService.getAll();
    }
    const entities = await orderService.getAll();
    res.status(200).json(entities);
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.get('/:id', async (req, res) => {
  const { id } = req.params;
  try {
    for(let i=0;i<19;i++){
      await orderService.getById(Number(id));
    }
    const entity = await orderService.getById(Number(id));
    res.status(200).json(entity);
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.post('/', async (req, res) => {
  const entity = req.body;
  try {
    for(let i=0;i<19;i++){
      await orderService.create(entity);
    }
    res.status(200).json(await orderService.create(entity));
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.put('/:id', async (req, res) => {
  const entity = req.body;
  const { id } = req.params;
  try {
    for(let i=0;i<20;i++){
      await orderService.update(Number(id), entity);
    }
    res.status(200).json("OK");
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.delete('/:id', async (req, res) => {
  const { id } = req.params;
  try {
    for(let i=0;i<20;i++){
      await orderService.delete(Number(id) - i);
    }
    res.status(200).json("OK");
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

export default router;