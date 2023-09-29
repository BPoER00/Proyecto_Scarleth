import React, { useEffect } from "react";
import InputSelect from "../Inputs/InputSelect";
import { useForm } from "react-hook-form";
import { useUsuario } from "@/context/Usuario.Context";

function Filtros({ setFiltros }) {
  const { usuario, rol } = useUsuario();
  const {
    formState: { errors },
    control,
    watch,
    reset,
  } = useForm();

  const usuarioId = (watch("usuario_id") || 0).toString();
  const rolId = (watch("rol_id") || 0).toString();

  useEffect(() => {
    const filtros = {
      usuarioId,
      rolId,
    };

    setFiltros(filtros);
  }, [usuarioId, rolId]);

  const handleReset = async () => {
    reset();
  };

  return (
    <div className="px-8 pt-6 pb-4 mb-1 dark:bg-gray-800 rounded">
      <div className="flex flex-wrap -mx-4">
        <div className="w-1/2 px-4 mb-4">
          <InputSelect
            label={"Usuario"}
            name={"usuario_id"}
            options={usuario}
            control={control}
            placeholder={"Usuario..."}
          />
        </div>
        <div className="w-1/2 px-4 mb-4">
          <InputSelect
            label={"Rol"}
            name={"rol_id"}
            options={rol}
            control={control}
            placeholder={"Rol..."}
          />
        </div>
        <div className="w-full text-right px-4">
          <button
            type="button"
            className="bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded"
            onClick={handleReset}
          >
            Limpiar Campos
          </button>
        </div>
      </div>
    </div>
  );
}

export default Filtros;
