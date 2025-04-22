const GenericRepository = (model, keyName) => {
    return {
      getAll: async () => model.findMany(),
  
      getById: async (id) => model.findUnique({ where: { [keyName]: id } }),
  
      create: async (data) => model.create({ data }),
  
      update: async (id, data) => model.update({
        where: { [keyName]: id },
        data,
      }),
  
      delete: async (id) => model.delete({
        where: { [keyName]: id },
      })
    };
  };
  
  module.exports = GenericRepository;