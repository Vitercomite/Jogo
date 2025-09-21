
#!/usr/bin/env bash
echo "Installer script for Extreme4X Mega Fusion (prototype)"
DEST=${1:-$HOME/Extreme4X_MegaFusion_install}
mkdir -p "$DEST"
echo "Copying files to $DEST..."
cp -r * "$DEST"
echo "Installation complete. To run: dotnet run --project $DEST -- 2025"
