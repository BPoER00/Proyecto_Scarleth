"use client";
import { createContext, useContext, useState } from "react";

const DashboardContext = createContext();

export const useDashboard = () => {
  const context = useContext(CargoContext);
  if (!context) throw new Error("useDashboard must used within a provider");
  return context;
};

function DashboardProvider({ children }) {

  return (
    <DashboardContext.Provider value={{}}>
      {children}
    </DashboardContext.Provider>
  );
}

export default DashboardProvider;
