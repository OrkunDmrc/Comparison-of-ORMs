import express from 'express';
import { CategoryService } from '../bll/services/categoryService';

const router = express.Router();
const categoryService = new CategoryService();

router.get('/', async (req, res) => {
    try{
        const entities = await categoryService.getAll();
        res.status(200).json(entities);
    }catch (err) {
        res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
    }
});

router.get('/:id', async (req, res) => {
    try{
        const entity = await categoryService.getById(Number(req.params.id));
        res.status(200).json(entity);
    }
    catch (err) {
        res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
    }
});

router.post('/', async (req, res) => {
    try{
        const entity = await categoryService.create(req.body);
        res.status(200).json(entity);
    }catch (err) {
        res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
    }
});

router.put('/:id', async (req, res) => {
    try{
        const entity = await categoryService.update(Number(req.params.id), req.body);
        res.status(200).json(entity);
    }catch (err) {
        res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
    }
});

router.delete('/:id', async (req, res) => {
    try{
        const entity = await categoryService.delete(Number(req.params.id));
        res.status(200).json(entity);
    }catch (err) {
        res.status(500).json({ message: err instanceof Error ? err.message : 'An unknown error occurred' });
    }
});

export default router;