"use client";
import { createContext, useContext, useState } from "react";
import { get } from "@/api/Cargo.Api";


const CargoContext = createContext();

export const useCargo = () => {
  const context = useContext(CargoContext);
  if (!context) throw new Error("useCargo must used within a provider");
  return context;
};

function CargoProvider({ children }) {
  const defaultPaginate = [
    { id: 1, name: "Lista de Cargo", status: "this" },
    { id: 2, name: "Nuevas Cargo", status: "other" },
  ];

  const [paginate, setPaginate] = useState(defaultPaginate);

  const changePage = (id) => {
    setPaginate((prevPaginate) =>
      prevPaginate.map((page) => ({
        ...page,
        status: page.id === id ? "this" : "other",
      }))
    );
  };

  const Cargos = async () => {
    const cargo = await get()
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return cargo;
  };

  return (
    <CargoContext.Provider value={{ Cargos, paginate, changePage }}>
      {children}
    </CargoContext.Provider>
  );
}

export default CargoProvider;
