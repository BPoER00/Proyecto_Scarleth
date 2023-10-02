import { useState } from 'react';

function Modal({ isOpen, onClose, title, children }) {
  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 flex items-center justify-center z-50">
      <div
        className="modal-overlay absolute w-full h-full bg-gray-900 opacity-50"
        onClick={onClose} // Cierra el modal al hacer clic fuera de él
      ></div>

      <div className="modal-container bg-white w-3/4 md:w-96 mx-auto rounded-lg shadow-lg z-50 overflow-y-auto">
        <div className="modal-content py-4 text-left px-6">
          <div className="modal-header">
            <h3 className="text-2xl font-semibold text-black">{title}</h3>
          </div>

          <div className="modal-body text-black">{children}</div>

          <div className="modal-footer mt-4">
            <button
              onClick={onClose}
              className="bg-gray-500 hover:bg-gray-600 text-white font-bold py-2 px-4 rounded"
            >
              Cerrar
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Modal;
