import express from 'express';
import { OrderDetailService } from '../bll/services/orderDetailService';

const router = express.Router();
const orderDetailService = new OrderDetailService();

router.get('/', async (req, res) => {
  try {
    const entities = await orderDetailService.getAll();
    res.status(200).json(entities);
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.get('/:orderID/:productID', async (req, res) => {
  const { orderID, productID } = req.query;
  try {
    const entity = await orderDetailService.getById(Number(orderID), Number(productID));
    res.status(200).json(entity);
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

router.post('/', async (req, res) => {
  const entity = req.body;
  try {
    res.status(200).json(await orderDetailService.create(entity));
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});


router.delete('/:orderID/:productID', async (req, res) => {
  const { orderID, productID } = req.params;
  try {
    res.status(200).json(await orderDetailService.delete(Number(orderID), Number(productID)));
  } catch (err) {
    res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
  }
});

export default router;